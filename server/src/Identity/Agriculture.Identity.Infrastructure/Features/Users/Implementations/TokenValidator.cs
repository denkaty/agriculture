using Agriculture.Identity.Application.Features.Users.Abstractions;
using Agriculture.Identity.Infrastructure.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Agriculture.Identity.Infrastructure.Features.Users.Implementations
{
    public class TokenValidator : ITokenValidator
    {
        private readonly ResetPasswordTokenOptions _options;

        public TokenValidator(IOptions<ResetPasswordTokenOptions> options)
        {
            _options = options.Value;
        }

        public bool IsValidResetPasswordToken(string resetPasswordToken)
        {
            try
            {
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(_options.SecurityKeyByteArray),
                    ValidAudience = _options.Audience,
                    ValidateAudience = true,
                    ValidIssuer = _options.Issuer,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(resetPasswordToken, validationParameters, out SecurityToken validatedToken);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
