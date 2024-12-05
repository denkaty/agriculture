using Agriculture.Items.Domain.Features.Items.Models.Entities;
using Agriculture.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Agriculture.Items.Infrastructure
{
    public class ItemsContext : DbContext
    {
        public ItemsContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Item> Items { get; set; }

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
