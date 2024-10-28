using FluentValidation;

namespace Agriculture.Identity.Application.Features.Users.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email).MinimumLength(5);
        }
    }
}
