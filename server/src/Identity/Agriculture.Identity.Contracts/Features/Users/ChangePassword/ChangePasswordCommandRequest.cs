namespace Agriculture.Identity.Contracts.Features.Users.ChangePassword
{
    public class ChangePasswordCommandRequest
    {
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
