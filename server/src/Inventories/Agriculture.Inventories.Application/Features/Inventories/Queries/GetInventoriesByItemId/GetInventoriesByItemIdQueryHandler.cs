using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Inventories.Inventories;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByItemId
{
    public class GetInventoriesByItemIdQueryHandler : IQueryHandler<GetInventoriesByItemIdQuery, GetInventoriesByItemIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;

        public GetInventoriesByItemIdQueryHandler(IAgricultureMapper mapper, IInventoryRepository inventoryRepository)
        {
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<GetInventoriesByItemIdQueryResult> Handle(GetInventoriesByItemIdQuery request, CancellationToken cancellationToken)
        {
            var paginationList = await _inventoryRepository.GetPaginatedByItemIdAsync(request.ItemId, cancellationToken, request.Page, request.PageSize, request.SortBy, request.SortOrder, request.SearchTerm);

            if (paginationList.Data.IsNullOrEmpty())
            {
                throw new InventoryEmptyCollectionException();
            }

            var result = _mapper.Map<GetInventoriesByItemIdQueryResult>(paginationList);

            return result;
        }
    }
}
