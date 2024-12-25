using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Inventories.Infrastructure.Features.Inventories.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => new { i.ItemId, i.WarehouseId });
        }
    }
}
