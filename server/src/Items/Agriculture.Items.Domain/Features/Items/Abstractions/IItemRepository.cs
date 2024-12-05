using Agriculture.Items.Domain.Features.Items.Models.Entities;

namespace Agriculture.Items.Domain.Features.Items.Abstractions
{
    public interface IItemRepository
    {
        Task AddAsync(Item item, CancellationToken cancellationToken);
        Task<bool> ExistsByCatalogNumberAsync(string catalogNumber, CancellationToken cancellationToken);
    }
}
