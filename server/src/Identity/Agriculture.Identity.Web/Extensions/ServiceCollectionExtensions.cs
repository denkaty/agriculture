using Agriculture.Shared.Web.Extensions;

namespace Agriculture.Identity.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddApiControllers()
               .AddSwagger()
               .AddJwtBearer(configuration)
               .AddAuthorizationPolicies()
               .AddVersioning()
               .AddCorsPolicies(configuration)
               .AddRateLimiterPolicies();

            return services;
        }
    }
}
