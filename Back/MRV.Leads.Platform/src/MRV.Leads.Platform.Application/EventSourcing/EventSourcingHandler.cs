using MRV.Leads.Platform.Application.Interfaces;
using MRV.Leads.Platform.Domain.Events;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.EventSourcing;

public class EventSourcingHandler<TEvent> : IEventSourcingHandler<TEvent>
    where TEvent : Event
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public EventSourcingHandler(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public async Task Handle(TEvent @event)
    {
        await _eventStoreRepository.SaveEventAsync(@event);
    }
}