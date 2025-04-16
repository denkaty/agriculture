using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Identity.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Identity.Infrastructure.Features.Users.Options;
using Agriculture.Shared.Common.Utilities;
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
            User? adminUser = await _userManager.FindByEmailAsync(_adminOptions.Email);

            if (adminUser != null) { return; }

            User admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = _adminOptions.Email,
                UserName = _adminOptions.Username,
                FirstName = _adminOptions.FirstName,
                LastName = _adminOptions.LastName
            };

            IdentityResult createResult = await _userManager.CreateAsync(admin, _adminOptions.Password);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    _logger.LogError($"Error creating admin user: {error.Description}");
                }
            }

            string emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(admin);

            IdentityResult emailConfirmationResult = await _userManager.ConfirmEmailAsync(admin, emailConfirmationToken);
            if(!emailConfirmationResult.Succeeded) 
            {
                foreach (var error in emailConfirmationResult.Errors)
                {
                    _logger.LogError($"Error confirming user`s email: {error.Description}");
                }
            }

            IdentityResult roleResult = await _userManager.AddToRoleAsync(admin, AppRoles.Admin);
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    _logger.LogError($"Error assigning user to role: {error.Description}");
                }
            }

        }
    }
}
