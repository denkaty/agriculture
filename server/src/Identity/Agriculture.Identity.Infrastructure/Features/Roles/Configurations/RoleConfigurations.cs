using Agriculture.Identity.Domain.Features.Roles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Identity.Infrastructure.Features.Roles.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        private const string ROLES_TABLE_NAME = "Roles";

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(ROLES_TABLE_NAME);
        }
    }
}
