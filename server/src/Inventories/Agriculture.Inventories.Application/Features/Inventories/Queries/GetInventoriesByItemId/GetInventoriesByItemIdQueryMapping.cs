using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId;
using Agriculture.Inventories.Contracts.Features.Inventories.Queries.ValidateSellOrder;
using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Shared.Domain.Models.Pagination;
using Mapster;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByItemId
{
    public class GetInventoriesByItemIdQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Inventory, GetInventoriesByItemIdQueryViewModel>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ItemId, src => src.ItemId)
            .Map(dest => dest.WarehouseId, src => src.WarehouseId)
            .Map(dest => dest.WarehouseName, src => src.Warehouse.Name)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToString())
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToString());

            config.NewConfig<PaginationList<Inventory>, GetInventoriesByItemIdQueryResult>()
                .Map(dest => dest.Data, src => src.Data.Adapt<List<GetInventoriesByItemIdQueryViewModel>>())
                .Map(dest => dest.Page, src => src.Page)
                .Map(dest => dest.PageSize, src => src.PageSize)
                .Map(dest => dest.TotalCount, src => src.TotalCount);

        }
    }
}
