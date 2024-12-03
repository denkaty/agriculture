using Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword;
using FluentValidation;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<RequestResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
        }
    }
}
