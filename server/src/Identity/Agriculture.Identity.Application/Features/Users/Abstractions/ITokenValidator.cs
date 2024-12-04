namespace Agriculture.Identity.Application.Features.Users.Abstractions
{
    public interface ITokenValidator
    {
        bool IsValidResetPasswordToken(string resetPasswordToken);
    }
}
