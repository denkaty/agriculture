using Agriculture.Shared.Application.Abstractions.CurrentUserContext;
using Agriculture.Shared.Application.Abstractions.DateTimeProvider;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.Messaging;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Domain.Models.Options;
using Agriculture.Shared.Infrastructure.Implementations.CurrentUserContext;
using Agriculture.Shared.Infrastructure.Implementations.DateTimeProvider;
using Agriculture.Shared.Infrastructure.Implementations.Mapper;
using Agriculture.Shared.Infrastructure.Implementations.MediatR;
using Agriculture.Shared.Infrastructure.Implementations.Messaging;
using Agriculture.Shared.Infrastructure.Models.Options;
using Agriculture.Shared.Infrastructure.Persistences;
using Agriculture.Shared.Infrastructure.Persistences.Interceptors;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agriculture.Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddScoped<IAgricultureMapper, AgricultureMapper>();

            return services;
        }

        public static IServiceCollection AddDatabaseContext<TDbContext>(
            this IServiceCollection serviceCollection,
            IConfiguration configuration,
            Action<DbContextOptionsBuilder>? optionsAction = null)
            where TDbContext : DbContext
        {
            serviceCollection
            .AddOptions<DatabaseOptions>()
            .BindConfiguration(nameof(DatabaseOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

            var databaseOptions = configuration
                        .GetSection(nameof(DatabaseOptions))
                        .Get<DatabaseOptions>()!;

            serviceCollection.AddDbContext<TDbContext>(options =>
            {
                options.AddInterceptors(new AuditableEntityInterceptor());

                options.UseSqlServer(
                        databaseOptions.ConnectionString,
                        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());

                optionsAction?.Invoke(options);
            });

            serviceCollection
                .AddHealthChecks()
                .AddDbContextCheck<TDbContext>();

            return serviceCollection;
        }

        public static IServiceCollection AddUnitOfWork<TDbContext>(this IServiceCollection serviceCollection)
            where TDbContext : DbContext
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(sp =>
            new UnitOfWork(sp.GetRequiredService<TDbContext>()));

            return serviceCollection;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAgricultureSender, AgricultureSender>();

            return serviceCollection;
        }

        public static IServiceCollection AddMessageBroker(
            this IServiceCollection serviceCollection,
            IConfiguration configuration,
            Assembly currentAssembly,
            Action<IBusRegistrationConfigurator>? configure = null)
        {
            serviceCollection
                .AddOptions<MessageBrokerOptions>()
                .BindConfiguration(nameof(MessageBrokerOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var messageBrokerOptions = configuration
                .GetSection(nameof(MessageBrokerOptions))
                .Get<MessageBrokerOptions>()!;

            serviceCollection.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumers(currentAssembly);

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(messageBrokerOptions.Host), host =>
                    {
                        host.Username(messageBrokerOptions.Username);
                        host.Password(messageBrokerOptions.Password);
                    });

                    configurator.ConfigureEndpoints(context);
                });

                configure?.Invoke(busConfigurator);
            });

            serviceCollection.AddScoped<IEventPublisher, EventPublisher>();

            return serviceCollection;
        }

        public static IServiceCollection AddCurrentUserContext(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddHttpContextAccessor()
                .AddScoped<ICurrentUserContext, CurrentUserContext>();

            return serviceCollection;
        }

        public static IServiceCollection AddDateTimeProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();

            return serviceCollection;
        }

    }
}
