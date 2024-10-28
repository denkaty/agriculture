using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Domain.Models.Options;
using Agriculture.Shared.Infrastructure.Implementations.Mapper;
using Agriculture.Shared.Infrastructure.Implementations.MediatR;
using Agriculture.Shared.Infrastructure.Persistences;
using Agriculture.Shared.Infrastructure.Persistences.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

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
            //serviceCollection.AddScoped<IUnitOfWork<TDbContext>, UnitOfWork<TDbContext>>(sp =>
            //new UnitOfWork<TDbContext>(sp.GetRequiredService<TDbContext>()));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(sp =>
            new UnitOfWork(sp.GetRequiredService<TDbContext>()));

            return serviceCollection;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAgricultureSender, AgricultureSender>();

            return serviceCollection;
        }

    }
}
