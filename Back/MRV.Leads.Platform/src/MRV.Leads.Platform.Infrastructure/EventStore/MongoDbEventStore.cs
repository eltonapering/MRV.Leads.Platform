using MongoDB.Driver;
using MRV.Leads.Platform.Domain.Events;

namespace MRV.Leads.Platform.Infrastructure.EventStore;

public class MongoDbEventStore : IEventStore
{
    private readonly IMongoCollection<Event> _eventCollection;

    public MongoDbEventStore(IMongoDatabase database, string collectionName)
    {
        _eventCollection = database.GetCollection<Event>(collectionName);
    }

    public async Task SaveEventAsync<T>(T @event) where T : Event
    {
        await _eventCollection.InsertOneAsync(@event);
    }

    public async Task<List<Event>> GetEventsAsync(string aggregateId)
    {
        return await _eventCollection.Find(e => e.Id == aggregateId).ToListAsync();
    }
}
