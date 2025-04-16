namespace Agriculture.Identity.Contracts.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandBindingModel
    {
        public ResetPasswordCommandBindingModel(string userId, string token, string newPassword, string confirmPassword)
        {
            UserId = userId;
            Token = token;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }

        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
