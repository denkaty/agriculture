using Agriculture.Identity.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;

namespace Agriculture.Identity.Infrastructure.DatabaseInitializers
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IMigrationSeeder _migrationSeeder;
        private readonly IRoleSeeder _rolesSeeder;
        private readonly IUserSeeder _userSeeder;

        public DatabaseInitializer(
            IMigrationSeeder migrationSeeder,
            IRoleSeeder rolesSeeder,
            IUserSeeder userSeeder)
        {
            _migrationSeeder = migrationSeeder;
            _rolesSeeder = rolesSeeder;
            _userSeeder = userSeeder;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            await _migrationSeeder.SeedAsync(cancellationToken);
            await _rolesSeeder.SeedAsync();
            await _userSeeder.SeedAsync();
        }
    }
}
