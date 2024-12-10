using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;

namespace Agriculture.Inventory.Web.Extensions
{
    public static class HostExtensions
    {
        public static async Task SetupDatabaseAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();

                await databaseInitializer.InitializeAsync(CancellationToken.None);
            }
        }
    }
}
