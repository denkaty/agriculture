using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Shared.Domain.Abstractions;

namespace Agriculture.Inventories.Domain.Features.Items.Abstractions
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<ICollection<Item>> GetByIdsAsync(ICollection<string> ids, CancellationToken cancellationToken);
    }
}
