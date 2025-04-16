using Agriculture.Identity.Application.Features.Users.Models;
namespace Agriculture.Identity.Infrastructure.Features.Users.Abstractions
{
    public interface IResetPasswordTokenGenerator
    {
        CreateResetPasswordTokenResult GenerateResetPasswordToken(string id, string email);
    }
}
