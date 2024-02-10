using MRV.Leads.Platform.Domain.Events;

namespace MRV.Leads.Platform.Infrastructure.EventStore;

public interface IEventStore
{
    Task SaveEventAsync<T>(T @event) where T : Event;
    Task<List<Event>> GetEventsAsync(string aggregateId);
}