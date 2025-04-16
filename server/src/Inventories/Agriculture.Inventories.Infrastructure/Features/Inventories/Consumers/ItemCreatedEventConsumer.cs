using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Inventories.Domain.Features.Warehouses.Abstractions;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Application.Events.Inventories.Items;
using MassTransit;

namespace Agriculture.Inventories.Infrastructure.Features.Inventories.Consumers
{
    public class ItemCreatedEventConsumer : IConsumer<ItemCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public ItemCreatedEventConsumer(IUnitOfWork unitOfWork, IWarehouseRepository warehouseRepository, IInventoryRepository inventoryRepository)
        {
            _unitOfWork = unitOfWork;
            _warehouseRepository = warehouseRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task Consume(ConsumeContext<ItemCreatedEvent> context)
        {
            var warehouses = await _warehouseRepository.GetPaginatedAsync(CancellationToken.None);

            var inventories = new List<Inventory>();
            foreach (var warehouse in warehouses.Data) 
            {
                var inventory = new Inventory()
                {
                    ItemId = context.Message.itemId,
                    WarehouseId = warehouse.Id,
                    Quantity = 0
                };
                inventories.Add(inventory);
            }

            await _inventoryRepository.AddRangeAsync(inventories, CancellationToken.None);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        }
    }
}
