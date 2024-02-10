using MediatR;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Enums;

namespace MRV.Leads.Platform.Application.CQRS.Queries;

public class GetIntentByStatusQuery : IRequest<IEnumerable<Intent>>
{
    public IntentStatus Status { get; set; }

    public GetIntentByStatusQuery(IntentStatus status)
    {
        Status = status;
    }
}