using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public record ChangePasswordCommand(string UserId, string Token, string NewPassword, string ConfirmPassword) : ICommand;
}
