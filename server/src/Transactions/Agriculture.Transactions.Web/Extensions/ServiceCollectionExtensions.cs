using Agriculture.Shared.Web.Extensions;

namespace Agriculture.Transactions.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddApiControllers()
               .ConfigureApiBehaviorOptions()
               .AddSwagger()
               .AddCorsPolicies(configuration)
               .AddJwtBearer(configuration)
               .AddAuthorizationPolicies()
               .AddVersioning()
               .AddRateLimiterPolicies();

            return services;
        }
    }
}
