using MRV.Leads.Platform.Domain.Common.Contracts;
using MRV.Leads.Platform.Domain.Enums;
using MRV.Leads.Platform.Domain.Validations;

namespace MRV.Leads.Platform.Domain.Entities;

public class Intent : EntityBase
{
    public Intent(Guid contactId, string suburb, Category category, string description, decimal price, IntentStatus? status)
          : base(Guid.NewGuid())
    {
        ContactId = contactId;
        Suburb = suburb;
        Category = category;
        Description = description;
        Price = price;
        Status = status;
    }

    public Guid ContactId { get; private set; }
    public virtual Contact Contact { get; private set; }
    public string Suburb { get; private set; }
    public Category Category { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public IntentStatus? Status { get; private set; }

    public bool ApplyDiscount()
    {
        if (Price > 500)
        {
            Price -= Price * 0.1m;
            return true;
        }

        return false;
    }

    public void Accept()
    {
        if (Status != IntentStatus.Accepted)
        {
            Status = IntentStatus.Accepted;
        }
    }

    public void Decline()
    {
        if (Status != IntentStatus.Declined)
        {
            Status = IntentStatus.Declined;
        }
    }

    public override bool IsValid()
    {
        var validator = new IntentValidation();
        var validationResult = validator.Validate(this);

        _errors.Clear();
        _errors.AddRange(validationResult.Errors);

        return validationResult.IsValid;
    }
}