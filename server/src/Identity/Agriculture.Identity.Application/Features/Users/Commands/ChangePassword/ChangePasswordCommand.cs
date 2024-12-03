using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public record ChangePasswordCommand(string UserId, string NewPassword, string ConfirmPassword) : ICommand;
}
