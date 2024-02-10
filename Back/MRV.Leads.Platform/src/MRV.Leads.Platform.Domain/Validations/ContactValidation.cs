using FluentValidation;
using MRV.Leads.Platform.Domain.Entities;
using System.Text.RegularExpressions;

namespace MRV.Leads.Platform.Domain.Validations;

public class ContactValidation : AbstractValidator<Contact>
{
    public ContactValidation()
    {
        RuleFor(contact => contact.FullName)
            .NotEmpty().WithMessage("The full name is required.")
            .MaximumLength(200).WithMessage("The full name must not exceed 200 characters.");

        RuleFor(contact => contact.PhoneNumber)
            .NotEmpty().WithMessage("The phone number is required.")
            .Matches(new Regex(@"^\+[1-9]\d{1,14}$")).WithMessage("The phone number is not in the correct format.");
    }
}
