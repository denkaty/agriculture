using Agriculture.Inventories.Domain.Features.Warehouses.Abstractions;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Inventories.Warehouses;

namespace Agriculture.Inventories.Application.Features.Warehouses.Commands.DeleteWarehouseById
{
    public class DeleteWarehouseByIdHandler : ICommandHandler<DeleteWarehouseByIdCommand>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWarehouseByIdHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteWarehouseByIdCommand request, CancellationToken cancellationToken)
        {
            var existingWarehouse = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingWarehouse == null)
            {
                throw new WarehouseNotFoundException(request.Id);
            }

            await _warehouseRepository.DeleteAsync(existingWarehouse, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
