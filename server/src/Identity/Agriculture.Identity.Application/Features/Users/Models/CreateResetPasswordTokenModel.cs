namespace Agriculture.Identity.Application.Features.Users.Models
{
    public record CreateResetPasswordTokenModel(string UserId, string Email);
}
