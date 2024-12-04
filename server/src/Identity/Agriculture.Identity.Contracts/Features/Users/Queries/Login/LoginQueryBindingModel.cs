namespace Agriculture.Identity.Contracts.Features.Users.Queries.Login
{
    public class LoginQueryBindingModel
    {
        public LoginQueryBindingModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
