using Agriculture.Transactions.Domain.Features.Suppliers.Abstractions;
using Agriculture.Transactions.Infrastructure.Features.Suppliers.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Transactions.Infrastructure.Features.Suppliers.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddSupplierServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddRepositories();

            return serviceCollection;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISupplierRepository, SupplierRepository>();

            return serviceCollection;
        }
    }
}
