using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Commands.Register
{
    public record RegisterCommand(
        string Email,
        string Password,
        string ConfirmPassword,
        string PhoneNumber,
        string FirstName,
        string LastName) 
        : ICommand<RegisterCommandResult>;
}
