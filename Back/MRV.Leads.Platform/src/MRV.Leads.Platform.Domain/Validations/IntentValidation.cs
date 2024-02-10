using FluentValidation;
using MRV.Leads.Platform.Domain.Entities;

namespace MRV.Leads.Platform.Domain.Validations;

public class IntentValidation : AbstractValidator<Intent>
{
    public IntentValidation()
    {
        RuleFor(intent => intent.Contact)
            .NotNull().WithMessage("The Contact must be provided.");

        RuleFor(intent => intent.Suburb)
            .NotNull().WithMessage("The Suburb must be provided.");

        RuleFor(intent => intent.Category)
            .NotNull().WithMessage("The Category must be provided.");

        RuleFor(intent => intent.Description)
            .NotEmpty().WithMessage("The Description is required.")
            .MaximumLength(500).WithMessage("The Description must not exceed 500 characters.");

        RuleFor(intent => intent.Price)
            .GreaterThan(0).WithMessage("The Price must be greater than zero.");

        RuleFor(intent => intent.Status)
            .IsInEnum().WithMessage("Invalid status.");
    }
}