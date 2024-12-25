using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Inventories.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Inventories.Infrastructure.DatabaseInitializers.Constants;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;

namespace Agriculture.Inventories.Infrastructure.DatabaseInitializers
{
    public class InventorySeeder : IInventorySeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryRepository _inventoryRepository;
        public InventorySeeder(IUnitOfWork unitOfWork, IInventoryRepository inventoryRepository)
        {
            _unitOfWork = unitOfWork;
            _inventoryRepository = inventoryRepository;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            var isSeeded = await _inventoryRepository.AnyAsync(cancellationToken);
            if (isSeeded) { return; }

            var inventories = GenerateInventories();
            await _inventoryRepository.AddRangeAsync(inventories, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private ICollection<Inventory> GenerateInventories()
        {
            var currentTime = DateTime.UtcNow;
            var inventories = new List<Inventory>()
            {
                new Inventory{Id = InventoryConstants.InventoryId1, ItemId = ItemConstants.ItemId1, WarehouseId = WarehouseConstants.WarehouseId1  , Quantity = 5, CreatedAt = currentTime},
                new Inventory{Id = InventoryConstants.InventoryId2, ItemId = ItemConstants.ItemId1, WarehouseId = WarehouseConstants.WarehouseId2 , Quantity = 0, CreatedAt = currentTime},
                new Inventory{Id = InventoryConstants.InventoryId3, ItemId = ItemConstants.ItemId2, WarehouseId = WarehouseConstants.WarehouseId1 , Quantity = 2, CreatedAt = currentTime},
                new Inventory{Id = InventoryConstants.InventoryId4, ItemId = ItemConstants.ItemId2, WarehouseId = WarehouseConstants.WarehouseId2 , Quantity = 0, CreatedAt = currentTime},
            };

            return inventories;
        }
    }
}
