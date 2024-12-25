using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Inventories.Inventories;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByWarehouseId
{
    public class GetInventoriesByWarehouseIdQueryHandler : IQueryHandler<GetInventoriesByWarehouseIdQuery, GetInventoriesByWarehouseIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;

        public GetInventoriesByWarehouseIdQueryHandler(IAgricultureMapper mapper, IInventoryRepository inventoryRepository)
        {
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }
        public async Task<GetInventoriesByWarehouseIdQueryResult> Handle(GetInventoriesByWarehouseIdQuery request, CancellationToken cancellationToken)
        {
            var paginationList = await _inventoryRepository.GetPaginatedByWarehouseIdAsync(request.WarehouseId, cancellationToken, request.Page, request.PageSize, request.SortBy, request.SortOrder, request.SearchTerm);

            if (paginationList.Data.IsNullOrEmpty())
            {
                throw new InventoryEmptyCollectionException();
            }

            var result = _mapper.Map<GetInventoriesByWarehouseIdQueryResult>(paginationList);

            return result;
        }
    }
}
