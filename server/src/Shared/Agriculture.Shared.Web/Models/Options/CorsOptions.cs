using System.ComponentModel.DataAnnotations;

namespace Agriculture.Shared.Web.Models.Options
{
    public class CorsOptions
    {
        [Required]
        public string AllowedOrigins { get; set; } = string.Empty;
    }
}
