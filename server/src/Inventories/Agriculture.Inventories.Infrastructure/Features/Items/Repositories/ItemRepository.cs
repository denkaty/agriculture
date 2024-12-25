using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Shared.Domain.Models.Pagination;
using Agriculture.Shared.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Inventories.Infrastructure.Features.Items.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(InventoriesContext dbContext) : base(dbContext)
        {
        }

        public override async Task<PaginationList<Item>> GetPaginatedAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<Item>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(item =>
                item.CatalogNumber.Contains(searchTerm) ||
                item.Name.Contains(searchTerm) ||
                item.Description.Contains(searchTerm));
            }

            Expression<Func<Item, object>> keySelector = sortBy.ToLower() switch
            {
                "catalogNumber" => item => item.CatalogNumber,
                "name" => item => item.Name,
                "description" => item => item.Description,
                _ => user => user.CatalogNumber,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(item => new Item
                                   {
                                       Id = item.Id,
                                       CatalogNumber = item.CatalogNumber,
                                       Name = item.Name,
                                       Description = item.Description,
                                       CreatedAt = item.CreatedAt,
                                       UpdatedAt = item.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<Item>(data, page, pageSize, totalCount);

            return paginationList;
        }
    }
}
