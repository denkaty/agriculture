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

            return serviceCollection;
        }
    }
}
