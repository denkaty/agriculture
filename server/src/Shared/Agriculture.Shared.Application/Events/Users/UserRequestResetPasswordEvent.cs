namespace Agriculture.Shared.Application.Events.Users
{
    public record UserRequestResetPasswordEvent(string Email, string RedirectUrl);
}
