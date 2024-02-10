using MediatR;

namespace MRV.Leads.Platform.Application.CQRS.Commands;

public class DeclineIntentCommand : IRequest
{
    public Guid IntentId { get; set; }

    public DeclineIntentCommand(Guid intentId)
    {
        IntentId = intentId;
    }
}