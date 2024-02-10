using MRV.Leads.Platform.Domain.Events;

namespace MRV.Leads.Platform.Application.Interfaces;

public interface IEventSourcingHandler<T> where T : Event
{
    Task Handle(T @event);
}
