using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Users;
using Agriculture.Shared.Common.Utilities;
using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Application.Features.Users.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RegisterCommandHandler(IAgricultureMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            User? existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null) { throw new UserEmailAlreadyTakenException(request.Email); }

            User user = _mapper.Map<User>(request);

            IdentityResult createResult = await _userManager.CreateAsync(user);
            if (!createResult.Succeeded)
            {
                throw new UserCreationException(request.Email);
            }

            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, AppRoles.Employee);
            if (!roleResult.Succeeded)
            {
                throw new UserRoleAssignmentException(AppRoles.Employee, request.Email);
            }

            RegisterCommandResult registerCommandResult = _mapper.Map<RegisterCommandResult>(user);

            return registerCommandResult;
        }
    }
}
