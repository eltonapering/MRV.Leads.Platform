using MongoDB.Driver;
using MRV.Leads.Platform.Domain.Events;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Infrastructure.Repositories;

public class EventStoreRepository : IEventStoreRepository
{
    private readonly IMongoCollection<IntentAcceptedEvent> _acceptedEvents;
    private readonly IMongoCollection<IntentDeclinedEvent> _declinedEvents;

    public EventStoreRepository(IMongoDatabase database)
    {
        _acceptedEvents = database.GetCollection<IntentAcceptedEvent>("AcceptedEvents");
        _declinedEvents = database.GetCollection<IntentDeclinedEvent>("DeclinedEvents");
    }

    public async Task SaveAcceptedEventAsync(IntentAcceptedEvent acceptedEvent)
    {
        await _acceptedEvents.InsertOneAsync(acceptedEvent);
    }

    public async Task SaveDeclinedEventAsync(IntentDeclinedEvent declinedEvent)
    {
        await _declinedEvents.InsertOneAsync(declinedEvent);
    }

    public async Task SaveEventAsync<TEvent>(TEvent @event) where TEvent : Event
    {
        
    }
}