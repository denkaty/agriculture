using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Shared.Domain.Abstractions;
using Agriculture.Shared.Domain.Models.Pagination;

namespace Agriculture.Inventories.Domain.Features.Inventories.Abstractions
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<PaginationList<Inventory>> GetByItemIdAsync(string itemId, CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "");
        Task<PaginationList<Inventory>> GetByWarehouseIdAsync(string warehouseId, CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "");
    }
}
