using MediatR;
using Microsoft.EntityFrameworkCore;
using MRV.Leads.Platform.Application.Events.Messages;
using MRV.Leads.Platform.Application.Events.Publishers;
using MRV.Leads.Platform.Application.Interfaces;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Events;
using MRV.Leads.Platform.Domain.Exceptions;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.CQRS.Commands.Handlers;

public class AcceptIntentCommandHandler : IRequestHandler<AcceptIntentCommand>
{
    private readonly IRepository<Intent> _intentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IntentAcceptedPublisher _publisher;
    private readonly IEventSourcingHandler<IntentAcceptedEvent> _eventSourcingHandler;

    public AcceptIntentCommandHandler(
        IRepository<Intent> intentRepository,
        IUnitOfWork unitOfWork,
        IEventSourcingHandler<IntentAcceptedEvent> eventSourcingHandler,
        IntentAcceptedPublisher publisher)
    {
        _intentRepository = intentRepository;
        _unitOfWork = unitOfWork;
        _eventSourcingHandler = eventSourcingHandler;
        _publisher = publisher;
    }

    public async Task<Unit> Handle(AcceptIntentCommand request, CancellationToken cancellationToken)
    {

        var intent = await _intentRepository.Query()
                                            .Include(i => i.Contact)
                                            .FirstOrDefaultAsync(i => i.Id == request.IntentId, cancellationToken);

        if (intent == null)
        {
            throw new NotFoundException("Intent not found.");
        }

        if (!intent.IsValid())
        {
            throw new DomainValidationException("Intent is not valid", intent.Errors);
        }

        intent.Accept();
        var discount = intent.ApplyDiscount();

        _intentRepository.Update(intent);
        await _unitOfWork.CompleteAsync();

        // Create the message to be published in RabbitMQ
        var message = new IntentAcceptedMessage
        {
            IntentId = intent.Id.ToString(),
            Email = intent.Contact.Email,
            Subject = "Lead Accepted",
            Body = intent.Description + $" Price : $ {intent.Price} Discount 10 % : {discount}"
        };

        // Publish the message
        _publisher.PublishIntentAccepted(message);

        //generate event sourcing        
        var acceptedEvent = new IntentAcceptedEvent
        {
            IntentId = intent.Id,
            OccurredOn = DateTime.Now
        };

        await _eventSourcingHandler.Handle(acceptedEvent);

        return Unit.Value;
    }
}