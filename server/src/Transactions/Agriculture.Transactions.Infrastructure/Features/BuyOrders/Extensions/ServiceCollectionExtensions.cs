using Agriculture.Transactions.Domain.Features.BuyOrders.Abstractions;
using Agriculture.Transactions.Infrastructure.Features.BuyOrders.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Transactions.Infrastructure.Features.BuyOrders.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddBuyOrderServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddRepositories();

            return serviceCollection;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBuyOrderRepository, BuyOrderRepository>();

            return serviceCollection;
        }
    }
}
