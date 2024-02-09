using MediatR;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Enums;

namespace MRV.Leads.Platform.Application.CQRS.Commands;

public class CreateIntentCommand : IRequest<Intent>
{
    public Guid ContactId { get; set; }
    public string Suburb { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}