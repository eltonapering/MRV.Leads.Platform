using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MRV.Leads.Platform.Domain.Events;

public abstract class Event
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; protected set; }
}
