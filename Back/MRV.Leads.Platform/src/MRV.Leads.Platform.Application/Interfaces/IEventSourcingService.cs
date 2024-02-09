using MRV.Leads.Platform.Domain.Events;

namespace MRV.Leads.Platform.Application.Interfaces;

public interface IEventSourcingService
{
    Task SaveAcceptedEventAsync(IntentAcceptedEvent acceptedEvent);
    Task SaveDeclinedEventAsync(IntentDeclinedEvent declinedEvent);
}
