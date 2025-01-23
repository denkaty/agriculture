using Agriculture.Inventories.Domain.Features.Inventories.Abstractions;
using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Shared.Domain.Models.Pagination;
using Agriculture.Shared.Infrastructure.Persistences;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Inventories.Infrastructure.Features.Inventories.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        private readonly InventoriesContext _context;
        public InventoryRepository(InventoriesContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<ICollection<(string ItemId, string WarehouseId)>> GetInvalidInventoriesAsync(ICollection<(string ItemId, string WarehouseId)> compositeKeys, CancellationToken cancellationToken)
        {
            var validInventories = await _context.Inventories
                .Where(x => compositeKeys.Select(k => k.ItemId).Contains(x.ItemId) &&
                            compositeKeys.Select(k => k.WarehouseId).Contains(x.WarehouseId))
                .Select(x => new { x.ItemId, x.WarehouseId })
                .ToListAsync(cancellationToken);

            var validInventoryKeys = new HashSet<(string ItemId, string WarehouseId)>(validInventories.Select(x => (ItemId: x.ItemId, WarehouseId: x.WarehouseId)));

            var invalidInventories = compositeKeys
                .Where(x => !validInventoryKeys.Contains((x.ItemId, x.WarehouseId)))
                .ToList();

            return invalidInventories;
        }

        public async Task<ICollection<Inventory>> GetInventoriesByWarehouseIdAndItemIdsAsync(string warehouseId, ICollection<string> itemIds, CancellationToken cancellationToken)
        {
            return await _context.Inventories
                .Where(x => x.WarehouseId == warehouseId && itemIds.Contains(x.ItemId))
                .ToListAsync(cancellationToken);
        }

        public async override Task<PaginationList<Inventory>> GetPaginatedAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<Inventory>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(inventory =>
                inventory.ItemId.Contains(searchTerm) ||
                inventory.WarehouseId.Contains(searchTerm));
            }

            Expression<Func<Inventory, object>> keySelector = sortBy.ToLower() switch
            {
                "itemId" => inventory => inventory.ItemId,
                "warehouseId" => inventory => inventory.WarehouseId,
                _ => inventory => inventory.ItemId,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(inventory => new Inventory
                                   {
                                       Id = inventory.Id,
                                       ItemId = inventory.ItemId,
                                       WarehouseId = inventory.WarehouseId,
                                       Quantity = inventory.Quantity,
                                       CreatedAt = inventory.CreatedAt,
                                       UpdatedAt = inventory.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<Inventory>(data, page, pageSize, totalCount);

            return paginationList;
        }

        public async Task<PaginationList<Inventory>> GetPaginatedByItemIdAsync(string itemId, CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<Inventory>().AsQueryable();

            query = query.Where(inventory => inventory.ItemId == itemId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(inventory =>
                inventory.ItemId.Contains(searchTerm) ||
                inventory.WarehouseId.Contains(searchTerm));
            }

            Expression<Func<Inventory, object>> keySelector = sortBy.ToLower() switch
            {
                "itemId" => inventory => inventory.ItemId,
                "warehouseId" => inventory => inventory.WarehouseId,
                _ => inventory => inventory.ItemId,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(inventory => new Inventory
                                   {
                                       Id = inventory.Id,
                                       ItemId = inventory.ItemId,
                                       WarehouseId = inventory.WarehouseId,
                                       Quantity = inventory.Quantity,
                                       CreatedAt = inventory.CreatedAt,
                                       UpdatedAt = inventory.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<Inventory>(data, page, pageSize, totalCount);

            return paginationList;
        }

        public async Task<PaginationList<Inventory>> GetPaginatedByWarehouseIdAsync(string itemId, CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<Inventory>().AsQueryable();

            query = query.Where(inventory => inventory.WarehouseId == itemId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(inventory =>
                inventory.ItemId.Contains(searchTerm) ||
                inventory.WarehouseId.Contains(searchTerm));
            }

            Expression<Func<Inventory, object>> keySelector = sortBy.ToLower() switch
            {
                "itemId" => inventory => inventory.ItemId,
                "warehouseId" => inventory => inventory.WarehouseId,
                _ => inventory => inventory.ItemId,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(inventory => new Inventory
                                   {
                                       Id = inventory.Id,
                                       ItemId = inventory.ItemId,
                                       WarehouseId = inventory.WarehouseId,
                                       Quantity = inventory.Quantity,
                                       CreatedAt = inventory.CreatedAt,
                                       UpdatedAt = inventory.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<Inventory>(data, page, pageSize, totalCount);

            return paginationList;
        }

        public async Task<ICollection<Inventory>> GetInventoriesByCompositeKeysAsync(ICollection<(string ItemId, string WarehouseId)> compositeKeys, CancellationToken cancellationToken)
        {
            if (compositeKeys == null || !compositeKeys.Any())
            {
                return new List<Inventory>();
            }

            var itemIds = compositeKeys.Select(key => key.ItemId).ToHashSet();
            var warehouseIds = compositeKeys.Select(key => key.WarehouseId).ToHashSet();

            return await _context.Inventories
                .Where(inventory => itemIds.Contains(inventory.ItemId) && warehouseIds.Contains(inventory.WarehouseId))
                .ToListAsync(cancellationToken);
        }
    }
}
