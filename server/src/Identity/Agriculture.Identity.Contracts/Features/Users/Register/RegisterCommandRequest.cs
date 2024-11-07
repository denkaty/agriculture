namespace Agriculture.Identity.Web.Features.Users.Models.Requests
{
    public class RegisterCommandRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;    

        public string ConfirmPassword { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
