﻿using Agriculture.Shared.Infrastructure.Extensions;
using Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities;
using Agriculture.Transactions.Domain.Features.Clients.Models.Entities;
using Agriculture.Transactions.Domain.Features.SellOrders.Models;
using Agriculture.Transactions.Domain.Features.Suppliers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Agriculture.Transactions.Infrastructure
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext(DbContextOptions<TransactionsContext> options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<BuyOrderItem> BuyOrderItems { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
        public DbSet<SellOrderItem> SellOrderItems { get; set; }

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
