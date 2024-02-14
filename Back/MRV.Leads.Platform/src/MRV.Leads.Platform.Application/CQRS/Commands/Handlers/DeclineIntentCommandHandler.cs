using MediatR;
using Microsoft.EntityFrameworkCore;
using MRV.Leads.Platform.Application.Interfaces;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Events;
using MRV.Leads.Platform.Domain.Exceptions;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.CQRS.Commands.Handlers;

public class DeclineIntentCommandHandler : IRequestHandler<DeclineIntentCommand>
{
    private readonly IRepository<Intent> _intentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventSourcingHandler<IntentDeclinedEvent> _eventSourcingHandler;

    public DeclineIntentCommandHandler(
                                       IRepository<Intent> intentRepository, 
                                       IUnitOfWork unitOfWork,
                                       IEventSourcingHandler<IntentDeclinedEvent> eventSourcingHandler)
    {
        _intentRepository = intentRepository;
        _unitOfWork = unitOfWork;
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task<Unit> Handle(DeclineIntentCommand request, CancellationToken cancellationToken)
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

        intent.Decline();
        await _unitOfWork.CompleteAsync();

        //generate event sourcing        
        var declineEvent = new IntentDeclinedEvent
        {
            IntentId = intent.Id,
            OccurredOn = DateTime.Now
        };

        await _eventSourcingHandler.Handle(declineEvent);

        return Unit.Value;
    }
}
