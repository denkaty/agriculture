using Agriculture.Shared.Application.PipelineBehaviors;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agriculture.Shared.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services, Assembly assembly)
        {
            TypeAdapterConfig.GlobalSettings.Scan(assembly);

            services.AddSingleton(TypeAdapterConfig.GlobalSettings);

            services.AddScoped<IMapper, Mapper>();

            return services;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection serviceCollection, Assembly assembly)
        {
            serviceCollection.AddMediatR(
                cf =>
                {
                    cf.RegisterServicesFromAssembly(assembly);

                    cf.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                });

            return serviceCollection;
        }

        public static IServiceCollection AddValidationBehavior(this IServiceCollection serviceCollection, Assembly assembly)
        {
            serviceCollection.AddValidatorsFromAssembly(assembly);

            return serviceCollection;
        }
    }
}
