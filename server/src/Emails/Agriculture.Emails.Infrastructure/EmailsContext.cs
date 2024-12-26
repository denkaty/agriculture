using Agriculture.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Agriculture.Emails.Infrastructure
{
    public class EmailsContext : DbContext
    {
        public EmailsContext(DbContextOptions<EmailsContext> options) : base(options)
        {
        }

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
