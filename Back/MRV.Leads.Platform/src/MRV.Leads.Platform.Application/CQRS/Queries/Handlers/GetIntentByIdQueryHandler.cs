using MediatR;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.CQRS.Queries.Handlers;

public class GetIntentByIdQueryHandler : IRequestHandler<GetIntentByIdQuery, Intent>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetIntentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Intent> Handle(GetIntentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Intents.GetByIdAsync(request.IntentId);
    }
}