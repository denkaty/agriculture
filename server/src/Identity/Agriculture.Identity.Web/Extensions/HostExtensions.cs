using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;

namespace Agriculture.Identity.Web.Extensions
{
    public static class HostExtensions
    {
        public static async Task SetupDatabaseAsync(this IHost host, CancellationToken cancellationToken = default)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();

                await databaseInitializer.InitializeAsync(cancellationToken);
            }
        }
    }
}
