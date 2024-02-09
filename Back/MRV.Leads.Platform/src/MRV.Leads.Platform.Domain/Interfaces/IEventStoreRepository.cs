using MRV.Leads.Platform.Domain.Events;

namespace MRV.Leads.Platform.Domain.Interfaces;

public interface IEventStoreRepository
{
    Task SaveAcceptedEventAsync(IntentAcceptedEvent acceptedEvent);
    Task SaveDeclinedEventAsync(IntentDeclinedEvent declinedEvent);
    Task SaveEventAsync<TEvent>(TEvent @event) where TEvent : Event;
}