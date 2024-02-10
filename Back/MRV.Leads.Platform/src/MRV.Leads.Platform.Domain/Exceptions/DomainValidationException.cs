using FluentValidation.Results;

namespace MRV.Leads.Platform.Domain.Exceptions;

public class DomainValidationException : Exception
{
    public IEnumerable<ValidationFailure> Errors { get; }

    public DomainValidationException(string message, IEnumerable<ValidationFailure> errors)
        : base(message)
    {
        Errors = errors ?? new List<ValidationFailure>();
    }
}