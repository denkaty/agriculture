namespace Agriculture.Identity.Application.Features.Users.Models
{
    public record CreateResetPasswordTokenResult(string Token, DateTime ValidUntil);
}
