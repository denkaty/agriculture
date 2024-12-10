using Agriculture.Inventories.Application.Features.Items.Queries.GetItems;
using Agriculture.Inventories.Domain.Features.Warehouses.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Common.Exceptions.Inventories.Warehouses;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouses
{
    public class GetWarehousesQueryHandler : IRequestHandler<GetWarehousesQuery, GetWarehousesQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;

        public GetWarehousesQueryHandler(IAgricultureMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<GetWarehousesQueryResult> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
        {
            var paginationList = await _warehouseRepository.GetAllAsync(cancellationToken, request.Page, request.PageSize, request.SortBy, request.SortOrder);
            if (paginationList.Items.IsNullOrEmpty())
            {
                throw new WarehouseEmptyCollectionException();
            }

            var result = _mapper.Map<GetWarehousesQueryResult>(paginationList);

            return result;
        }
    }
}
