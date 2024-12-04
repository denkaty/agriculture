namespace Agriculture.Shared.Application.Events.Users
{
    public record UserRequestedResetPasswordEvent(string Email, string RedirectUrl);
}
