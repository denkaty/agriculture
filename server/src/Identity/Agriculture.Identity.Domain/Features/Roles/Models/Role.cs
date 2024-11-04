using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Domain.Features.Roles.Models
{
    public class Role : IdentityRole<string>
    {
        public Role() : base() 
        {
        }

        public Role(string roleName) : base(roleName)
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
