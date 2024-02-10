namespace MRV.Leads.Platform.Domain.Events;

public class IntentDeclinedEvent : Event
{
    public Guid IntentId { get; set; }
    public DateTime OccurredOn { get; set; }
}