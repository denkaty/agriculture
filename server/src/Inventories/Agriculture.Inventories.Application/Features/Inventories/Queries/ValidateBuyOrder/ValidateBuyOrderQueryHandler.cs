using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.ValidateBuyOrder
{
    public class ValidateBuyOrderQueryHandler : IQueryHandler<ValidateBuyOrderQuery, ValidateBuyOrderQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;

        public ValidateBuyOrderQueryHandler(IAgricultureMapper mapper, IInventoryRepository inventoryRepository)
        {
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<ValidateBuyOrderQueryResult> Handle(ValidateBuyOrderQuery request, CancellationToken cancellationToken)
        {
            var compositeKeys = request.CompositeKeys.Select(x => (ItemId: x.ItemId, WarehouseId: x.WarehouseId)).ToList();

            ICollection<(string ItemId, string WarehouseId)> invalidInventories = await _inventoryRepository.GetInvalidInventoriesAsync(compositeKeys, cancellationToken);
            var result = _mapper.Map<ValidateBuyOrderQueryResult>(invalidInventories);
            return result;
        }

    }
}
