using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Identity.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Identity.Infrastructure.Features.Users.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Agriculture.Identity.Infrastructure.DatabaseInitializers
{
    public class UserSeeder : IUserSeeder
    {
        private readonly AdminOptions _adminOptions;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserSeeder> _logger;

        public UserSeeder(
            IOptions<AdminOptions> adminOptions,
            UserManager<User> userManager,
            ILogger<UserSeeder> logger)
        {
            _adminOptions = adminOptions.Value;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            var adminUser = await _userManager.FindByEmailAsync(_adminOptions.Email);

            if (adminUser != null) { return; }

            User admin = new User(_adminOptions.Username, _adminOptions.Email);

            var result = await _userManager.CreateAsync(admin, _adminOptions.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError($"Error creating admin user: {error.Description}");
                }
            }

            await _userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
