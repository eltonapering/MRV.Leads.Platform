using MRV.Leads.Platform.Application.Interfaces;
using MRV.Leads.Platform.Domain.Events;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.Services;

public class EventSourcingService : IEventSourcingService
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public EventSourcingService(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public async Task SaveAcceptedEventAsync(IntentAcceptedEvent acceptedEvent)
    {
        await _eventStoreRepository.SaveAcceptedEventAsync(acceptedEvent);
    }

    public async Task SaveDeclinedEventAsync(IntentDeclinedEvent declinedEvent)
    {
        await _eventStoreRepository.SaveDeclinedEventAsync(declinedEvent);
    }
}