using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Inventory.Infrastructure.DatabaseInitializers
{
    public class MigrationSeeder : IMigrationSeeder
    {
        private readonly IUnitOfWork _unitOfWork;

        public MigrationSeeder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            var pendingMigrations = await _unitOfWork.Database.GetPendingMigrationsAsync(cancellationToken);

            if (pendingMigrations.Any())
            {
                await _unitOfWork.Database.MigrateAsync(cancellationToken);
            }
        }
    }
}
