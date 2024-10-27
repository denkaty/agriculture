using Agriculture.Shared.Application.Abstractions.Mapper;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agriculture.Shared.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapper(this IServiceCollection services, Assembly assembly)
        {
            TypeAdapterConfig.GlobalSettings.Scan(assembly);

            services.AddSingleton(TypeAdapterConfig.GlobalSettings);

            services.AddScoped<IMapper, Mapper>();

            return services;
        }
    }
}
