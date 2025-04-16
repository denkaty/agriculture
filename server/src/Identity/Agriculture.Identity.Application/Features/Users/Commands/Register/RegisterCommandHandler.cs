using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.Messaging;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Application.Events.Users;
using Agriculture.Shared.Common.Exceptions.Users;
using Agriculture.Shared.Common.Utilities;
using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Application.Features.Users.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;
        private readonly UserManager<User> _userManager;

        public RegisterCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, UserManager<User> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
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

            UserCreatedEvent userCreatedEvent = _mapper.Map<UserCreatedEvent>(user);
            await _eventPublisher.PublishAsync(userCreatedEvent, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            RegisterCommandResult registerCommandResult = _mapper.Map<RegisterCommandResult>(user);

            return registerCommandResult;
        }
    }
}
