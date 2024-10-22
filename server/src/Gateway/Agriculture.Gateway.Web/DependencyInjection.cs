using Agriculture.Shared.Web;

namespace Agriculture.Gateway.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
               .AddApiControllers()
               .AddSwagger()
               .AddJwtBearer(configuration)
               .AddAuthorizationPolicies();

            return services;
        }

    }
}
