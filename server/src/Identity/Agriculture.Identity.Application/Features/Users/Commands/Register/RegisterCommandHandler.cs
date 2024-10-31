using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterCommandResult>
    {
        public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            User? user = new User() { Id = Guid.NewGuid().ToString() };
            
            return new RegisterCommandResult(user.Id);
        }
    }
}
