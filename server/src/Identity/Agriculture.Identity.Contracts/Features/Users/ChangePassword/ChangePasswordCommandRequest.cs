namespace Agriculture.Identity.Contracts.Features.Users.ChangePassword
{
    public class ChangePasswordCommandRequest
    {
        public string Email { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;
    }
}
