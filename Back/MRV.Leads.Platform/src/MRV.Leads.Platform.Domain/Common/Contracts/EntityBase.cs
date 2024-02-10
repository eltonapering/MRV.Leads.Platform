using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRV.Leads.Platform.Domain.Common.Contracts;

public abstract class EntityBase
{
    protected EntityBase()
    {
    }

    protected EntityBase(Guid id)
    {
        Id = id;
        CreatedDate = DateTime.UtcNow;
        Active = true;
    }

    public virtual Guid Id { get; protected set; }
    public DateTime CreatedDate { get; private set; }
    public bool Active { get; private set; } 

    public abstract bool IsValid();

    [NotMapped]
    protected readonly List<ValidationFailure> _errors = new List<ValidationFailure>();

    [NotMapped]
    public IReadOnlyCollection<ValidationFailure> Errors => _errors.AsReadOnly();
}