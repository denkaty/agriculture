using Agriculture.Identity.Application.Features.Users.Abstractions;
using Agriculture.Identity.Application.Features.Users.Models;
using Agriculture.Shared.Application.Abstractions.DateTimeProvider;
using Agriculture.Shared.Common.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Agriculture.Identity.Infrastructure.Features.Users.Implementations
{
    public class AccessTokenGenerator : IAccessTokenGenerator
    {
        private readonly AccessTokenOptions _accessTokenOptions;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AccessTokenGenerator(IOptions<AccessTokenOptions> accessTokenOptions, IDateTimeProvider dateTimeProvider)
        {
            _accessTokenOptions = accessTokenOptions.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public CreateAccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel)
        {
            var validUntil = _dateTimeProvider.UtcNow.AddSeconds(_accessTokenOptions.LifetimeSeconds);

            var signingKey = new SymmetricSecurityKey(_accessTokenOptions.SecurityKeyByteArray);

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, createAccessTokenModel.UserId),
                new Claim(ClaimTypes.NameIdentifier, createAccessTokenModel.UserId),
                new Claim(ClaimTypes.Email, createAccessTokenModel.Email),
                new Claim(ClaimTypes.GivenName, createAccessTokenModel.FirstName),
                new Claim(ClaimTypes.Surname, createAccessTokenModel.LastName),
            });

            claimsIdentity.AddClaims(createAccessTokenModel.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                Issuer = _accessTokenOptions.Issuer,
                Audience = _accessTokenOptions.Audience,
                Expires = validUntil
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new CreateAccessTokenResult(token, validUntil);
        }
    }
}
