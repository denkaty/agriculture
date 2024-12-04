using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Commands.ResetPassword
{
    public record ResetPasswordCommand(string UserId, string Token, string NewPassword, string ConfirmPassword) : ICommand;
}
