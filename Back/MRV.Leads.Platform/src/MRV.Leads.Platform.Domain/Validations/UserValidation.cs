using FluentValidation;
using MRV.Leads.Platform.Domain.Entities;

namespace MRV.Leads.Platform.Domain.Validations;

public class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(user => user.Login)
            .NotEmpty().WithMessage("Login is required.")
            .Length(3, 100).WithMessage("Login must be between 3 and 100 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not in a correct format.");
    }
}
