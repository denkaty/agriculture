using Agriculture.Shared.Application.Abstractions.CurrentUserContext;
using Agriculture.Shared.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace Agriculture.Shared.Infrastructure.Implementations.CurrentUserContext
{
    public class CurrentUserContext : ICurrentUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor?.HttpContext?.User.GetUserId() ?? string.Empty;
        }
    }
}
