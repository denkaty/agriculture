using FluentValidation;

namespace Agriculture.Identity.Application.Features.Users.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(query => query.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(query => query.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
