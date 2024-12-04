namespace Agriculture.Identity.Contracts.Features.Users.Commands.Register
{
    public class RegisterCommandBindingModel
    {
        public RegisterCommandBindingModel(string email, string password, string confirmPassword, string phoneNumber, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
