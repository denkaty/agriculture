using Agriculture.Emails.Infrastructure.Features.Emails.Extensions;
using Agriculture.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agriculture.Emails.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services
                .AddDatabaseContext<EmailsContext>(configuration)
                .AddMessageBroker(configuration, assembly, busConfigurator => busConfigurator.AddTransactionalOutbox<EmailsContext>())
                .AddEmailServices(configuration);

            return services;
        }
    }
}
