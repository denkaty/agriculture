namespace Agriculture.Identity.Contracts.Features.Users.Commands.RequestResetPassword
{
    public class RequestResetPasswordCommandBindingModel
    {
        public RequestResetPasswordCommandBindingModel(string email)
        {
            Email = email;
        }
        public string Email { get; set; } = string.Empty;
    }
}
