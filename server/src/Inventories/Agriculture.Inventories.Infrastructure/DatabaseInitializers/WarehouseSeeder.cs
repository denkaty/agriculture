using Agriculture.Inventories.Domain.Features.Warehouses.Abstractions;
using Agriculture.Inventories.Domain.Features.Warehouses.Models.Entities;
using Agriculture.Inventories.Infrastructure.DatabaseInitializers.Abstractions;
using Agriculture.Inventories.Infrastructure.DatabaseInitializers.Constants;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;

namespace Agriculture.Inventories.Infrastructure.DatabaseInitializers
{
    public class WarehouseSeeder : IWarehouseSeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseSeeder(IUnitOfWork unitOfWork, IWarehouseRepository warehouseRepository)
        {
            _unitOfWork = unitOfWork;
            _warehouseRepository = warehouseRepository;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            var isSeeded = await _warehouseRepository.AnyAsync(cancellationToken);
            if (isSeeded) { return; }

            var warehouses = GenerateWarehouses();
            await _warehouseRepository.AddRangeAsync(warehouses, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private ICollection<Warehouse> GenerateWarehouses()
        {
            var currentTime = DateTime.UtcNow;
            var warehouses = new List<Warehouse>()
            {
                new Warehouse{Id = WarehouseConstants.WarehouseId1, Name = "BS_K", Location="Karnobat, Burgas, Bulgaria", CreatedAt = currentTime},
                new Warehouse{Id = WarehouseConstants.WarehouseId2, Name = "BS_ST", Location="Stara Zagora, Bulgaria", CreatedAt = currentTime},
            };

            return warehouses;
        }
    }
}
