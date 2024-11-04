using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Domain.Features.Users.Models.Entities
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
