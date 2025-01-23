using Agriculture.Transactions.Domain.Features.Clients.Abstractions;
using Agriculture.Transactions.Infrastructure.Features.Clients.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Transactions.Infrastructure.Features.Clients.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddClientsServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddRepositories();

            return serviceCollection;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IClientRepository, ClientRepository>();

            return serviceCollection;
        }
    }
}
