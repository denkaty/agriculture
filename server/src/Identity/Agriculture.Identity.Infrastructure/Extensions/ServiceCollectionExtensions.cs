using Agriculture.Identity.Application.Features.Users.Abstractions;
using Agriculture.Identity.Domain.Features.Roles.Models;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Identity.Infrastructure.DatabaseInitializers;
using Agriculture.Identity.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Identity.Infrastructure.Features.Roles.Options;
using Agriculture.Identity.Infrastructure.Features.Users.Abstractions;
using Agriculture.Identity.Infrastructure.Features.Users.Implementations;
using Agriculture.Identity.Infrastructure.Features.Users.Options;
using Agriculture.Identity.Infrastructure.Models.Options;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Infrastructure.Extensions;
using Agriculture.Shared.Infrastructure.Implementations.MediatR;
using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agriculture.Identity.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services
                .AddMapper()
                .AddDatabaseContext<IdentityContext>(configuration)
                .AddDatabaseIdentity()
                .AddUnitOfWork<IdentityContext>()
                .AddMediatR()
                .AddMessageBroker(configuration, assembly, busConfigurator => busConfigurator.AddTransactionalOutbox<IdentityContext>())
                .AddCurrentUserContext()
                .AddRoleOptions()
                .AddAdminOptions()
                .AddDatabaseInitializers()
                .AddDateTimeProvider()
                .AddAccessTokenGenerator()
                .AddResetPasswordRelated()
                .AddUrlRelated();

            return services;
        }

        private static IServiceCollection AddDatabaseIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddIdentity<User, Role>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            return serviceCollection;
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
                .AddScoped<IRoleSeeder, RoleSeeder>()
                .AddScoped<IUserSeeder, UserSeeder>()
                .AddScoped<IDatabaseInitializer, DatabaseInitializer>();

            return serviceCollection;
        }

        private static IServiceCollection AddRoleOptions(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddOptions<RoleOptions>()
                .BindConfiguration(nameof(RoleOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return serviceCollection;
        }

        private static IServiceCollection AddAdminOptions(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddOptions<AdminOptions>()
                .BindConfiguration(nameof(AdminOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return serviceCollection;
        }

        private static IServiceCollection AddAccessTokenGenerator(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccessTokenGenerator, AccessTokenGenerator>();

            return serviceCollection;
        }

        private static IServiceCollection AddResetPasswordRelated(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddOptions<ResetPasswordTokenOptions>()
                .BindConfiguration(nameof(ResetPasswordTokenOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            serviceCollection.AddScoped<IResetPasswordTokenGenerator, ResetPasswordTokenGenerator>();

            return serviceCollection;
        }

        private static IServiceCollection AddUrlRelated(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddOptions<UrlOptions>()
                .BindConfiguration(nameof(UrlOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            serviceCollection.AddScoped<IUrlHandler, UrlHandler>();

            return serviceCollection;
        }

    }
}
