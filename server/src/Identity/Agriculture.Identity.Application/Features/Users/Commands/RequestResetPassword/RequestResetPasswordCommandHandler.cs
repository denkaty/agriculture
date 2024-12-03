using Agriculture.Identity.Application.Features.Users.Abstractions;
using Agriculture.Identity.Application.Features.Users.Models;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Identity.Infrastructure.Features.Users.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.Messaging;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Application.Events.Users;
using Agriculture.Shared.Common.Exceptions.Users;
using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword
{
    public class RequestResetPasswordCommandHandler : ICommandHandler<RequestResetPasswordCommand>
    {
        private readonly IAgricultureMapper _agricultureMapper;
        private readonly UserManager<User> _userManager;
        private readonly IResetPasswordTokenGenerator _resetPasswordTokenGenerator;
        private readonly IUrlHandler _urlHandler;
        private readonly IEventPublisher _eventPublisher;
        private readonly IUnitOfWork _unitOfWork;

        public RequestResetPasswordCommandHandler(
            IAgricultureMapper agricultureMapper,
            UserManager<User> userManager,
            IResetPasswordTokenGenerator resetPasswordTokenGenerator,
            IUrlHandler urlHandler,
            IEventPublisher eventPublisher,
            IUnitOfWork unitOfWork)
        {
            _agricultureMapper = agricultureMapper;
            _userManager = userManager;
            _resetPasswordTokenGenerator = resetPasswordTokenGenerator;
            _urlHandler = urlHandler;
            _eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RequestResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new UserNotFoundException(request.Email);
            }

            var generateResetPasswordTokenResponse = _resetPasswordTokenGenerator.GenerateResetPasswordToken(user.Id, request.Email);

            var url = _urlHandler.ConfigureResetPasswordUrl(user.Id, generateResetPasswordTokenResponse.Token);

            var userResetPasswordTokenCreatedEvent = _agricultureMapper.Map<UserRequestedResetPasswordEvent>((user.Email, url));

            await _eventPublisher.PublishAsync(userResetPasswordTokenCreatedEvent, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
