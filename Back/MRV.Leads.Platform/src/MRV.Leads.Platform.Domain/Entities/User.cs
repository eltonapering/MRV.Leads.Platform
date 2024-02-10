using MRV.Leads.Platform.Domain.Common.Contracts;
using MRV.Leads.Platform.Domain.Exceptions;
using MRV.Leads.Platform.Domain.Validations;

namespace MRV.Leads.Platform.Domain.Entities;

public class User : EntityBase
{
    public User(Guid id, string login, string email, string passwordHash)
    {
        Id = id;
        Login = login;
        Email = email;
        PasswordHash = passwordHash;

        Validate();
    }

    public string Login { get; protected set; }
    public string Email { get; protected set; }
    public string PasswordHash { get; protected set; }

    public void SetLogin(string login)
    {
        Login = login;
        Validate();
    }

    public void SetEmail(string email)
    {
        Email = email;
        Validate();
    }

    public override bool IsValid()
    {
        var validationResult = new UserValidation().Validate(this);
        _errors.Clear();
        _errors.AddRange(validationResult.Errors);
        return validationResult.IsValid;
    }

    private void Validate()
    {
        if (!IsValid())
        {
            throw new DomainValidationException("Intent is not valid", Errors);
        }
    }
}
