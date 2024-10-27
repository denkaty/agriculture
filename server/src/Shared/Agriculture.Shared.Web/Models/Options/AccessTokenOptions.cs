using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agriculture.Shared.Web.Models.Options
{
    public class AccessTokenOptions
    {
        [Required]
        public string SecretKey { get; init; }

        public byte[] SecretKeyByteArray => Encoding.UTF8.GetBytes(SecretKey);

        [Required]
        public int ExpirationTimeInMinutes { get; init; } = 60;

        [Required]
        public string Issuer { get; init; }

        [Required]
        public string Audience { get; init; }
    }
}
