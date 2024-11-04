namespace Agriculture.Identity.Web.Features.Users.Models.Requests
{
    public class RegisterCommandRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
