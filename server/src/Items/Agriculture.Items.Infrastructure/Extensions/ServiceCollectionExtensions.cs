﻿using Agriculture.Items.Domain.Features.Items.Abstractions;
using Agriculture.Items.Infrastructure.DatabaseInitializers;
using Agriculture.Items.Infrastructure.Features.Items.Repositories;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Infrastructure.Extensions;
using Agriculture.Shared.Infrastructure.Implementations.MediatR;
using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agriculture.Items.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services
                .AddMapper()
                .AddDatabaseContext<ItemsContext>(configuration)
                .AddUnitOfWork<ItemsContext>()
                .AddMediatR()
                .AddMessageBroker(configuration, assembly, busConfigurator => busConfigurator.AddTransactionalOutbox<ItemsContext>())
                .AddCurrentUserContext()
                .AddDatabaseInitializers()
                .AddDateTimeProvider()
                .AddRepositories();

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

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IItemRepository, ItemRepository>();

            return serviceCollection;
        }

    }
}
