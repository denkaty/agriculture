using Agriculture.Identity.Application.Features.Users.Abstractions;
using Agriculture.Identity.Application.Features.Users.Models;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Users;
using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Application.Features.Users.Queries.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, LoginQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public LoginQueryHandler(
            IAgricultureMapper mapper,
            UserManager<User> userManager,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<LoginQueryResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new UserNotFoundException(request.Email);
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
            {
                throw new UserInvalidPasswordException(request.Email);
            }

            var createAccessTokenModel = _mapper.Map<CreateAccessTokenModel>(user);

            var createAccessTokenResult = _accessTokenGenerator.GenerateAccessToken(createAccessTokenModel);

            var loginQueryResult = _mapper.Map<LoginQueryResult>(createAccessTokenResult);

            return loginQueryResult;
        }
    }
}
