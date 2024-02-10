using MediatR;

namespace MRV.Leads.Platform.Application.CQRS.Commands;

public class AcceptIntentCommand : IRequest
{
    public Guid IntentId { get; set; }

    public AcceptIntentCommand(Guid intentId)
    {
        IntentId = intentId;
    }
}
