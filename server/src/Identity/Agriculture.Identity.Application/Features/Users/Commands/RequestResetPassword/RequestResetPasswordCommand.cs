using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword
{
    public record RequestResetPasswordCommand(string Email) : ICommand;
}
