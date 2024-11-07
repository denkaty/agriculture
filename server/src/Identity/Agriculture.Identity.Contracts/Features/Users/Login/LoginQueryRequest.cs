namespace Agriculture.Identity.Contracts.Features.Users.Login
{
    public class LoginQueryRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
