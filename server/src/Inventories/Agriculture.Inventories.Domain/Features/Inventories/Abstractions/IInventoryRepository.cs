using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Shared.Domain.Abstractions;
using Agriculture.Shared.Domain.Models.Pagination;

namespace Agriculture.Inventories.Domain.Features.Inventories.Abstractions
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<ICollection<Inventory>> GetInventoriesByWarehouseIdAndItemIdsAsync(string warehouseId, ICollection<string> itemIds, CancellationToken cancellationToken);
        Task<PaginationList<Inventory>> GetPaginatedByItemIdAsync(string itemId, CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "");
        Task<PaginationList<Inventory>> GetPaginatedByWarehouseIdAsync(string warehouseId, CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "");
        Task<ICollection<(string ItemId, string WarehouseId)>> GetInvalidInventoriesAsync(ICollection<(string ItemId, string WarehouseId)> compositeKeys, CancellationToken cancellationToken);
        Task<ICollection<Inventory>> GetInventoriesByCompositeKeysAsync(ICollection<(string ItemId, string WarehouseId)> compositeKeys, CancellationToken cancellationToken);
    }
}
