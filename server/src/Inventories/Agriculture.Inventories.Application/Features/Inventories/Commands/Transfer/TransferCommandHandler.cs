using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Inventories.Inventories;

namespace Agriculture.Inventories.Application.Features.Inventories.Commands.Transfer
{
    public class TransferCommandHandler : ICommandHandler<TransferCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryRepository _inventoryRepository;

        public TransferCommandHandler(IUnitOfWork unitOfWork, IInventoryRepository inventoryRepository)
        {
            _unitOfWork = unitOfWork;
            _inventoryRepository = inventoryRepository;
        }

        public async Task Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            string sourceWarehouseId = request.SourceWarehouseId;
            string destinationWarehouseId = request.DestinationWarehouseId;
            var itemIDs = request.Items.Select(x => x.ItemId).ToHashSet();

            var sourceInventories = await _inventoryRepository.GetInventoriesByWarehouseIdAndItemIdsAsync(sourceWarehouseId, itemIDs, cancellationToken);
            foreach (var item in request.Items)
            {
                var inventory = sourceInventories.FirstOrDefault(x => x.ItemId == item.ItemId);
                if (inventory == null)
                {
                    throw new InventoryItemNotFoundException(item.ItemId);
                }

                if (inventory!.Quantity < item.Quantity)
                {
                    throw new InventoryInsufficientQuantityException(item.ItemId, item.Quantity, inventory.Quantity);
                }
            }

            foreach (var item in request.Items)
            {
                var inventory = sourceInventories.First(x => x.ItemId == item.ItemId);
                inventory.Quantity -= item.Quantity;
            }

            var destinationInventories = await _inventoryRepository.GetInventoriesByWarehouseIdAndItemIdsAsync(destinationWarehouseId, itemIDs, cancellationToken);

            foreach (var item in request.Items)
            {
                var inventory = destinationInventories.FirstOrDefault(i => i.ItemId == item.ItemId);

                if (inventory == null)
                {
                    throw new InventoryItemNotFoundException(item.ItemId);
                }
                inventory!.Quantity += item.Quantity;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
