using Agriculture.Identity.Application.Features.Users.Models;

namespace Agriculture.Identity.Application.Features.Users.Abstractions
{
    public interface IAccessTokenGenerator
    {
        CreateAccessTokenResult GenerateAccessToken(CreateAccessTokenModel createAccessTokenModel);
    }
}
