using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;

namespace Agriculture.Items.Infrastructure.DatabaseInitializers
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IMigrationSeeder _migrationSeeder;

        public DatabaseInitializer(IMigrationSeeder migrationSeeder)
        {
            _migrationSeeder = migrationSeeder;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            await _migrationSeeder.SeedAsync(cancellationToken);
        }
    }
}
