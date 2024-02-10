using MediatR;
using MRV.Leads.Platform.Application.Interfaces;
using MRV.Leads.Platform.Domain.Events;
using MRV.Leads.Platform.Domain.Exceptions;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.CQRS.Commands.Handlers;

public class DeclineIntentCommandHandler : IRequestHandler<DeclineIntentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventSourcingHandler<IntentDeclinedEvent> _eventSourcingHandler;

    public DeclineIntentCommandHandler(IUnitOfWork unitOfWork,
                                       IEventSourcingHandler<IntentDeclinedEvent> eventSourcingHandler)
    {
        _unitOfWork = unitOfWork;
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task<Unit> Handle(DeclineIntentCommand request, CancellationToken cancellationToken)
    {
        var intent = await _unitOfWork.Intents.GetByIdAsync(request.IntentId);

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
