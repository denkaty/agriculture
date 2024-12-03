using FluentValidation;

namespace Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword
{
    public class RequestResetPasswordCommandValidator : AbstractValidator<RequestResetPasswordCommand>
    {
        public RequestResetPasswordCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
