using System.ComponentModel.DataAnnotations;

namespace Agriculture.Shared.Domain.Models.Options
{
    public class DatabaseOptions
    {
        [Required]
        public string ConnectionString { get; set; } = string.Empty;
    }
}
