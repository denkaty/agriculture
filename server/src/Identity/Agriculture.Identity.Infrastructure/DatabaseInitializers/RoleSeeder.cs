using Agriculture.Identity.Domain.Features.Roles.Models.Entities;
using Agriculture.Identity.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Identity.Infrastructure.Features.Roles.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Agriculture.Identity.Infrastructure.DatabaseInitializers
{
    public class RoleSeeder : IRoleSeeder
    {
        private readonly RoleOptions _roleOptions;
        private readonly RoleManager<Role> _roleManager;

        public RoleSeeder(IOptions<RoleOptions> roleOptions, RoleManager<Role> roleManager)
        {
            _roleOptions = roleOptions.Value;
            _roleManager = roleManager;
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            var roles = _roleOptions.Roles;

            foreach (var roleName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    var role = new Role(roleName);
                    await _roleManager.CreateAsync(role);
                }
            }
        }
    }
}
