using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Inventories.Domain.Features.Warehouses.Abstractions;
using Agriculture.Inventories.Domain.Features.Warehouses.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.Messaging;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Inventories.Warehouses;

namespace Agriculture.Inventories.Application.Features.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandHandler : ICommandHandler<CreateWarehouseCommand, CreateWarehouseCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;
        private readonly IWarehouseRepository _warehouseRepository;

        public CreateWarehouseCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _warehouseRepository = warehouseRepository;
        }

        public async Task<CreateWarehouseCommandResult> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var isWarehouseExisting = await _warehouseRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (isWarehouseExisting)
            {
                throw new WarehouseAlreadyExistsException(request.Name);
            }

            var warehouse = _mapper.Map<Warehouse>(request);

            await _warehouseRepository.AddAsync(warehouse, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<CreateWarehouseCommandResult>(warehouse);

            return result;
        }
    }
}
