using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Base;
using Agriculture.Shared.Common.Exceptions.Users;
using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ChangePasswordCommandHandler(IAgricultureMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            User? existingUser = await _userManager.FindByIdAsync(request.UserId);
            if (existingUser == null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            bool isPasswordConfirmed = request.NewPassword == request.ConfirmPassword;
            if (!isPasswordConfirmed)
            {
                throw new UserPasswordMismatchException();
            }

            string identityPasswordResetToken = await _userManager.GeneratePasswordResetTokenAsync(existingUser);
            var changePasswordResult = await _userManager.ResetPasswordAsync(existingUser, identityPasswordResetToken, request.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                var validationFailures = changePasswordResult.Errors
                .GroupBy(
                    error => error.Code,
                    error => error.Description,
                    (code, descriptions) => new
                    {
                        Code = code,
                        Descriptions = descriptions.ToArray()
                    })
                .ToDictionary(
                    item => item.Code,
                    item => item.Descriptions);

                throw new ValidationException(validationFailures);
            }

        }
    }
}
