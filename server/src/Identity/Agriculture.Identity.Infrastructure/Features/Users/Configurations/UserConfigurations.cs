using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agriculture.Identity.Infrastructure.Features.Users.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        private const string USERS_TABLE_NAME = "Users";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(USERS_TABLE_NAME);
        }
    }
}
