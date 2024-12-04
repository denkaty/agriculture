using System.ComponentModel.DataAnnotations;

namespace Agriculture.Identity.Infrastructure.Models.Options
{
    public class UrlOptions
    {
        [Required]
        public string ResetPasswordUrlTemplate { get; set; } = string.Empty;
    }
}
