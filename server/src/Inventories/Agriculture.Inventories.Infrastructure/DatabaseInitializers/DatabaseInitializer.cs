using Agriculture.Inventories.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;

namespace Agriculture.Inventories.Infrastructure.DatabaseInitializers
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IMigrationSeeder _migrationSeeder;
        private readonly IWarehouseSeeder _warehouseSeeder;
        private readonly IItemSeeder _itemSeeder;
        private readonly IInventorySeeder _inventorySeeder;

        public DatabaseInitializer(IMigrationSeeder migrationSeeder, IWarehouseSeeder warehouseSeeder, IItemSeeder itemSeeder, IInventorySeeder inventorySeeder)
        {
            _migrationSeeder = migrationSeeder;
            _warehouseSeeder = warehouseSeeder;
            _itemSeeder = itemSeeder;
            _inventorySeeder = inventorySeeder;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            await _migrationSeeder.SeedAsync(cancellationToken);
            await _warehouseSeeder.SeedAsync(cancellationToken);
            await _itemSeeder.SeedAsync(cancellationToken);
            await _inventorySeeder.SeedAsync(cancellationToken);
        }
    }
}
