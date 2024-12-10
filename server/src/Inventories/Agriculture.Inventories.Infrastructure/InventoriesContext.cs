using Agriculture.Inventories.Domain.Features.Inventories.Models.Entities;
using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Inventories.Domain.Features.Warehouses.Models.Entities;
using Agriculture.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Agriculture.Inventories.Infrastructure
{
    public class InventoriesContext : DbContext
    {
        public InventoriesContext(DbContextOptions<InventoriesContext> options) : base(options) 
        { 
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Assembly assembly = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(assembly);
            builder.ApplyTransactionalOutboxEntityConfiguration();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
