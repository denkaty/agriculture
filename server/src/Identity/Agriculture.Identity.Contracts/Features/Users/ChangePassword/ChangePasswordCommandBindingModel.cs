namespace Agriculture.Identity.Contracts.Features.Users.ChangePassword
{
    public class ChangePasswordCommandBindingModel
    {
        public ChangePasswordCommandBindingModel(string newPassword, string confirmPassword) 
        {
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }

        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
