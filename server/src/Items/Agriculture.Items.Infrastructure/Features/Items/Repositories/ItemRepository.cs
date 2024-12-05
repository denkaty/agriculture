using Agriculture.Items.Domain.Features.Items.Abstractions;
using Agriculture.Items.Domain.Features.Items.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Items.Infrastructure.Features.Items.Repositories
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
    }
}
