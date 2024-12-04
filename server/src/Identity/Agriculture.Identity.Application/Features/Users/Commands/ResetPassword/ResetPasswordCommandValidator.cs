using Agriculture.Identity.Application.Features.Users.Commands.ResetPassword;
using FluentValidation;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword).WithMessage("Passwords do not match.");
        }
    }
}
