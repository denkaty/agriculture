using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Infrastructure.Implementations.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Shared.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddScoped<IAgricultureMapper, AgricultureMapper>();

            return services;
        }
    }
}
