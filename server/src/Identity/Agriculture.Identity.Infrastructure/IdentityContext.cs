using Agriculture.Identity.Domain.Features.Roles.Models;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Agriculture.Identity.Infrastructure
{
    public class IdentityContext : IdentityDbContext<User, Role, string>
    {
        protected IdentityContext()
        {
        }

        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

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
