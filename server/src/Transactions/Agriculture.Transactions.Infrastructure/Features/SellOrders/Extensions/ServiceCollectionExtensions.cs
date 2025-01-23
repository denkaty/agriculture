using Agriculture.Transactions.Domain.Features.SellOrders.Abstractions;
using Agriculture.Transactions.Infrastructure.Features.SellOrders.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Transactions.Infrastructure.Features.SellOrders.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddSellOrderServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddRepositories();

            return serviceCollection;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISellOrderRepository, SellOrderRepository>();

            return serviceCollection;
        }
    }
}
