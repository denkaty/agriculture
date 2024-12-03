using Agriculture.Identity.Application.Features.Users.Models;
using Agriculture.Identity.Infrastructure.Features.Users.Abstractions;
using Agriculture.Identity.Infrastructure.Models.Options;
using Agriculture.Shared.Application.Abstractions.DateTimeProvider;
using Agriculture.Shared.Common.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Agriculture.Identity.Infrastructure.Features.Users.Implementations
{
    public class ResetPasswordTokenGenerator : IResetPasswordTokenGenerator
    {
        private readonly ResetPasswordTokenOptions _resetPasswordTokenOptions;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ResetPasswordTokenGenerator(IOptions<ResetPasswordTokenOptions> options, IDateTimeProvider dateTimeProvider)
        {
            _resetPasswordTokenOptions = options.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public CreateResetPasswordTokenResult GenerateResetPasswordToken(string id, string email)
        {
            var validUntil = _dateTimeProvider.UtcNow.AddSeconds(_resetPasswordTokenOptions.LifetimeSeconds);

            var signingKey = new SymmetricSecurityKey(_resetPasswordTokenOptions.SecurityKeyByteArray);

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id),
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Email, email),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                Issuer = _resetPasswordTokenOptions.Issuer,
                Audience = _resetPasswordTokenOptions.Audience,
                Expires = validUntil
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new CreateResetPasswordTokenResult(token, validUntil);
        }
    }
}
