using FluentValidation;

namespace Agriculture.Transactions.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.TaxIdentificationNumber)
               .NotEmpty().WithMessage("Tax Identification Number is required.")
               .Length(10, 15).WithMessage("Tax Identification Number must be between 10 and 15 characters.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

            RuleFor(x => x.ContactPerson)
                .MaximumLength(100).WithMessage("Contact Person must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.ContactPerson));
        }
    }
}
