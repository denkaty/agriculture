using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Shared.Domain.Models.Pagination;

namespace Agriculture.Inventories.Domain.Features.Items.Abstractions
{
    public interface IItemRepository
    {
        Task AddAsync(Item item, CancellationToken cancellationToken);
        Task<bool> ExistsByCatalogNumberAsync(string catalogNumber, CancellationToken cancellationToken);
        Task<Item?> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<PaginationList<Item>> GetUsersAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "");
        void Delete(Item item);
    }
}
