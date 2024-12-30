using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.BuyOrders;
using Agriculture.Shared.Common.Exceptions.Transactions.Suppliers;
using Agriculture.Transactions.Application.HttpClients;
using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Transactions.Domain.Features.BuyOrders.Abstractions;
using Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities;
using Agriculture.Transactions.Domain.Features.Suppliers.Abstractions;
using MediatR;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Commands.CreateBuyOrder
{
    public class CreateBuyOrderCommandHandler : IRequestHandler<CreateBuyOrderCommand, CreateBuyOrderCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBuyOrderRepository _buyOrderRepository;
        private readonly IInventoryHttpClient _inventoryHttpClient;
        private readonly ISupplierRepository _supplierRepository;

        public CreateBuyOrderCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, IBuyOrderRepository buyOrderRepository, IInventoryHttpClient inventoryHttpClient, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _buyOrderRepository = buyOrderRepository;
            _inventoryHttpClient = inventoryHttpClient;
            _supplierRepository = supplierRepository;
        }

        public async Task<CreateBuyOrderCommandResult> Handle(CreateBuyOrderCommand command, CancellationToken cancellationToken)
        {
            var validateBuyOrderQueryRequest = _mapper.Map<ValidateBuyOrderQueryRequest>(command);

            var validateBuyOrderQueryResponse = await _inventoryHttpClient.ValidateBuyOrderAsync(validateBuyOrderQueryRequest, cancellationToken);

            if (!validateBuyOrderQueryResponse.IsValid)
            {
                var invalidKeysMessage = string.Join("; ", validateBuyOrderQueryResponse.InvalidCompositeKeys
                    .Select(x => $"ItemId: {x.ItemId}, WarehouseId: {x.WarehouseId}"));

                throw new BuyOrderInventoryNotFoundException(invalidKeysMessage);
            }

            var isSupplierExisting = await _supplierRepository.AnyAsync(x => x.Id == command.SupplierId, cancellationToken);
            if(!isSupplierExisting)
            {
                throw new SupplierNotFoundException(command.SupplierId);
            }

            var buyOrder = _mapper.Map<BuyOrder>(command);

            await _buyOrderRepository.AddAsync(buyOrder, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<CreateBuyOrderCommandResult>(buyOrder);

            return result;
        }
    }
}
