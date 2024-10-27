using Agriculture.Shared.Web;

namespace Agriculture.Identity.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
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
