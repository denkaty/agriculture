using Agriculture.Inventories.Domain.Features.Warehouses.Abstractions;
using Agriculture.Inventories.Domain.Features.Warehouses.Models.Entities;
using Agriculture.Shared.Domain.Models.Pagination;
using Agriculture.Shared.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Inventories.Infrastructure.Features.Warehouses.Repositories
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(InventoriesContext dbContext) : base(dbContext)
        {
        }

        public override async Task<PaginationList<Warehouse>> GetPaginatedAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<Warehouse>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(item =>
                item.Name.Contains(searchTerm) ||
                item.Location.Contains(searchTerm));

            }

            Expression<Func<Warehouse, object>> keySelector = sortBy.ToLower() switch
            {
                "name" => warehouse => warehouse.Name,
                "location" => warehouse => warehouse.Location,
                _ => warehouse => warehouse.Name,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var warehouses = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(item => new Warehouse
                                   {
                                       Id = item.Id,
                                       Name = item.Name,
                                       Location = item.Location,
                                       CreatedAt = item.CreatedAt,
                                       UpdatedAt = item.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<Warehouse>(warehouses, page, pageSize, totalCount);

            return paginationList;
        }
    }
}
