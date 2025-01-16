using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder;
using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateSellOrder
{
    public class ValidateSellOrderQueryHandler : IQueryHandler<ValidateSellOrderQuery, ValidateSellOrderQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;
        public ValidateSellOrderQueryHandler(IAgricultureMapper mapper, IInventoryRepository inventoryRepository)
        {
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<ValidateSellOrderQueryResult> Handle(ValidateSellOrderQuery request, CancellationToken cancellationToken)
        {
            var compositeKeys = request.InventorySellItemOrders
                .Select(x => (x.ItemId, x.WarehouseId))
                .ToList();

            var inventories = await _inventoryRepository.GetInventoriesByCompositeKeysAsync(compositeKeys, cancellationToken);

            var notFoundCompositeKeyInventories = new List<NotFoundCompositeKeyInventory>();
            var insufficientQuantityInventories = new List<InsufficientQuantityInventory>();

            var inventoryLookup = inventories.ToDictionary(
                inventory => new InventoryCompositeKey { ItemId = inventory.ItemId, WarehouseId = inventory.WarehouseId },
                inventory => inventory.Quantity
            );

            foreach (var order in request.InventorySellItemOrders)
            {
                var compositeKey = new InventoryCompositeKey { ItemId = order.ItemId, WarehouseId = order.WarehouseId };

                if (!inventoryLookup.TryGetValue(compositeKey, out var availableQuantity))
                {
                    var notFoundCompositeKeyInventory = _mapper.Map<NotFoundCompositeKeyInventory>(compositeKey);
                    notFoundCompositeKeyInventories.Add(notFoundCompositeKeyInventory);
                }
                else
                {
                    if (availableQuantity < order.RequestedQuantity)
                    {
                        var insufficientQuantityInventory = _mapper.Map<InsufficientQuantityInventory>((compositeKey, order.RequestedQuantity, availableQuantity));

                        insufficientQuantityInventories.Add(insufficientQuantityInventory);
                    }
                }
            }
            // TODO: Not mapping correctly
            //var result = _mapper.Map<ValidateSellOrderQueryResult>((notFoundCompositeKeyInventories, insufficientQuantityInventories));  
            var result = new ValidateSellOrderQueryResult
            {
                NotFoundCompositeKeyInventories = notFoundCompositeKeyInventories,
                InsufficientQuantityInventories = insufficientQuantityInventories,
                IsValid = !notFoundCompositeKeyInventories.Any() && !insufficientQuantityInventories.Any()
            };

            return result;
        }
    }
}
