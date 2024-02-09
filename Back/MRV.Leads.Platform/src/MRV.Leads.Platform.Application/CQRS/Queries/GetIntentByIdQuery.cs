using MediatR;
using MRV.Leads.Platform.Domain.Entities;

namespace MRV.Leads.Platform.Application.CQRS.Queries;

public class GetIntentByIdQuery : IRequest<Intent>
{
    public Guid IntentId { get; set; }

    public GetIntentByIdQuery(Guid intentId)
    {
        IntentId = intentId;
    }
}