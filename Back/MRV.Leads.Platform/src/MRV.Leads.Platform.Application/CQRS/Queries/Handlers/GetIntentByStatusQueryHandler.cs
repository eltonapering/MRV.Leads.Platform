using MediatR;
using Microsoft.EntityFrameworkCore;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Interfaces;

namespace MRV.Leads.Platform.Application.CQRS.Queries.Handlers;

public class GetIntentByStatusQueryHandler : IRequestHandler<GetIntentByStatusQuery, IEnumerable<Intent>>
{
    private readonly IUnitOfWork _unitOfWork;    

    public GetIntentByStatusQueryHandler(IUnitOfWork unitOfWork)
    {   
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Intent>> Handle(GetIntentByStatusQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Intents
                                 .Query() 
                                 .Include(i => i.Contact) 
                                 .Where(i => i.Status == request.Status) 
                                 .ToListAsync();
    }
}