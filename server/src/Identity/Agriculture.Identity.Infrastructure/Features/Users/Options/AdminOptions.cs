using System.ComponentModel.DataAnnotations;

namespace Agriculture.Identity.Infrastructure.Features.Users.Options
{
    public class AdminOptions
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
