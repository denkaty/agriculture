using Agriculture.Identity.Application.Features.Users.Abstractions;
using Agriculture.Identity.Infrastructure.Models.Options;
using Microsoft.Extensions.Options;

namespace Agriculture.Identity.Infrastructure.Features.Users.Implementations
{
    public class UrlHandler : IUrlHandler
    {
        private readonly UrlOptions _options;

        public UrlHandler(IOptions<UrlOptions> options)
        {
            _options = options.Value;
        }

        public string ConfigureResetPasswordUrl(string id, string token)
        {
            var url = String.Format(_options.ResetPasswordUrlTemplate, id, token);

            return url;
        }
    }
}
