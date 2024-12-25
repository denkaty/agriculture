using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Inventories.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Inventories.Infrastructure.DatabaseInitializers.Constants;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;

namespace Agriculture.Inventories.Infrastructure.DatabaseInitializers
{
    public class ItemSeeder : IItemSeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemRepository _itemRepository;
        public ItemSeeder(IUnitOfWork unitOfWork, IItemRepository itemRepository)
        {
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            var isSeeded = await _itemRepository.AnyAsync(cancellationToken);
            if (isSeeded) { return; }

            var warehouses = GenerateItems();
            await _itemRepository.AddRangeAsync(warehouses, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private ICollection<Item> GenerateItems()
        {
            var currentTime = DateTime.UtcNow;
            var items = new List<Item>()
            {
                new Item{Id = ItemConstants.ItemId1, CatalogNumber = "0002446891", Name = "Ремък", Description = "1550x200", BasePrice=560, CreatedAt = currentTime},
                new Item{Id = ItemConstants.ItemId2, CatalogNumber = "0003572240", Name = "Лагер", Description = "Axion 720", BasePrice=30, CreatedAt = currentTime},
            };

            return items;
        }
    }
}
