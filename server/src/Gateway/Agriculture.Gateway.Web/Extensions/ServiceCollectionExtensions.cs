using Agriculture.Shared.Web.Extensions;

namespace Agriculture.Gateway.Web.Extensions
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

            services
                .AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"));

            return services;
        }

    }
}
