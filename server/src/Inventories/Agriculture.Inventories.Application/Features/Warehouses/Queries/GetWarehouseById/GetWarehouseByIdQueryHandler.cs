using Agriculture.Inventories.Domain.Features.Warehouses.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Inventories.Warehouses;

namespace Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouseById
{
    public class GetWarehouseByIdQueryHandler : IQueryHandler<GetWarehouseByIdQuery, GetWarehouseByIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;

        public GetWarehouseByIdQueryHandler(IAgricultureMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<GetWarehouseByIdQueryResult> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            var existingWarehouse = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
            if(existingWarehouse == null)
            {
                throw new WarehouseNotFoundException(request.Id);
            }

            var result = _mapper.Map<GetWarehouseByIdQueryResult>(existingWarehouse);

            return result;
        }
    }
}
