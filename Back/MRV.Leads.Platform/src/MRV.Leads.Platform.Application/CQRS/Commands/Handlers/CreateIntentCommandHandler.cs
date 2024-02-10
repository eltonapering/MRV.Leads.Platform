using MediatR;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Enums;
using MRV.Leads.Platform.Infrastructure;

namespace MRV.Leads.Platform.Application.CQRS.Commands.Handlers;

public class CreateIntentCommandHandler : IRequestHandler<CreateIntentCommand, Intent>
{
    private readonly ApplicationDbContext _context;

    public CreateIntentCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Intent> Handle(CreateIntentCommand request, CancellationToken cancellationToken)
    {   
        var intent = new Intent(
            contactId: request.ContactId,
            suburb: request.Suburb,
            category: request.Category,
            description: request.Description,
            price: request.Price,
            status: null
        );

        _context.Intents.Add(intent);
        await _context.SaveChangesAsync(cancellationToken);

        return intent;
    }
}