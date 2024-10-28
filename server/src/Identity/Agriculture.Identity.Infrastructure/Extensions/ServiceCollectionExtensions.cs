﻿using Agriculture.Identity.Domain.Features.Roles.Models;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Infrastructure.Extensions;
using Agriculture.Shared.Infrastructure.Implementations.MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Identity.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMapper()
                .AddDatabaseContext<IdentityContext>(configuration)
                .AddDatabaseIdentity()
                .AddUnitOfWork<IdentityContext>()
                .AddMediatR();

            return services;
        }

        private static IServiceCollection AddDatabaseIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddIdentity<User, Role>()
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


    }
}
