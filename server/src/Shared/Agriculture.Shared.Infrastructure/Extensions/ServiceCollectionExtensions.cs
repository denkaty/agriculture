using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Infrastructure.Implementations.Mapper;
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
    }
}
