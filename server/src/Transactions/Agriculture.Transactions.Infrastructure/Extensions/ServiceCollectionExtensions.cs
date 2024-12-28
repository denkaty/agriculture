using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Infrastructure.Extensions;
using Agriculture.Shared.Infrastructure.Implementations.MediatR;
using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;
using Agriculture.Transactions.Infrastructure.DatabaseInitializers;
using Agriculture.Transactions.Infrastructure.Features.Clients.Extensions;
using Agriculture.Transactions.Infrastructure.Features.Suppliers.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agriculture.Transactions.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services
                .AddMapper()
                .AddDatabaseContext<TransactionsContext>(configuration)
                .AddUnitOfWork<TransactionsContext>()
                .AddMediatR()
                .AddMessageBroker(configuration, assembly, busConfigurator => busConfigurator.AddTransactionalOutbox<TransactionsContext>())
                .AddCurrentUserContext()
                .AddDatabaseInitializers()
                .AddDateTimeProvider()
                .AddSupplierServices(configuration)
                .AddClientsServices(configuration);

            return services;
        }

        private static IServiceCollection AddMediatR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAgricultureSender, AgricultureSender>();

            return serviceCollection;
        }

        private static IServiceCollection AddDatabaseInitializers(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IMigrationSeeder, MigrationSeeder>()
                .AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            return serviceCollection;
        }

    }
}
