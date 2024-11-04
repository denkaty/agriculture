using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Domain.Features.Users.Models.Entities
{
    public class User : IdentityUser<string>
    {
        public User() : base()
        {
        }

        public User(string userName, string email) : base(userName)
        {
            Id = Guid.NewGuid().ToString();
            Email = email;
        }
    }
}
