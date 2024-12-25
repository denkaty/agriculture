using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouseById
{
    public record GetWarehouseByIdQuery(string Id) : IQuery<GetWarehouseByIdQueryResult>;
}
