using MRV.Leads.Platform.Application.Interfaces;
using MRV.Leads.Platform.Domain.Events;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.Services;

public class EventSourcingHandler<T> : IEventSourcingHandler<T> where T : Event
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public EventSourcingHandler(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public async Task Handle(T @event)
    {
        switch (@event)
        {
            case IntentAcceptedEvent acceptedEvent:
                await _eventStoreRepository.SaveAcceptedEventAsync(acceptedEvent);
                break;
            case IntentDeclinedEvent declinedEvent:
                await _eventStoreRepository.SaveDeclinedEventAsync(declinedEvent);
                break;
            // Add more cases as per your events
            default:
                throw new ArgumentException("Unsupported event type.", nameof(@event));
        }
    }
}