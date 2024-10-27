using Agriculture.Shared.Web.Extensions;

namespace Agriculture.Gateway.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
               .AddApiControllers()
               .AddSwagger()
               .AddJwtBearer(configuration)
               .AddAuthorizationPolicies()
               .AddVersioning();

            return services;
        }

    }
}
