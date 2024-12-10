using Agriculture.Inventory.Domain.Features.Items.Abstractions;
using Agriculture.Inventory.Domain.Features.Items.Models.Entities;
using Agriculture.Shared.Domain.Models.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Inventory.Infrastructure.Features.Items.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemsContext _context;

        public ItemRepository(ItemsContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item, CancellationToken cancellationToken)
        {
            await _context.Items.AddAsync(item, cancellationToken);
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
        }

        public async Task<bool> ExistsByCatalogNumberAsync(string catalogNumber, CancellationToken cancellationToken)
        {
            bool isExisting = await _context.Items
                .AsNoTracking()
                .AnyAsync(x => x.CatalogNumber == catalogNumber, cancellationToken);

            return isExisting;
        }

        public async Task<Item?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            Item? item = await _context.Items.FindAsync(id, cancellationToken);

            return item;
        }

        public async Task<PaginationList<Item>> GetUsersAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Items.AsQueryable();

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
            var items = await query.Skip((page - 1) * pageSize)
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

            var paginationList = new PaginationList<Item>(items, page, pageSize, totalCount);

            return paginationList;
        }
    }
}
