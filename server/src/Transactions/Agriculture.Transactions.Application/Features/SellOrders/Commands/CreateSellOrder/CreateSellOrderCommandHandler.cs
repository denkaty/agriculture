using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.Clients;
using Agriculture.Shared.Common.Exceptions.Transactions.SellOrders;
using Agriculture.Transactions.Application.HttpClients;
using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateSellOrder;
using Agriculture.Transactions.Domain.Features.Clients.Abstractions;
using Agriculture.Transactions.Domain.Features.SellOrders.Abstractions;
using Agriculture.Transactions.Domain.Features.SellOrders.Models;
using MediatR;

namespace Agriculture.Transactions.Application.Features.SellOrders.Commands.CreateSellOrder
{
    public class CreateSellOrderCommandHandler : IRequestHandler<CreateSellOrderCommand, CreateSellOrderCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryHttpClient _inventoryHttpClient;
        private readonly ISellOrderRepository _sellOrderRepository;
        private readonly IClientRepository _clientRepository;

        public CreateSellOrderCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, IInventoryHttpClient inventoryHttpClient, ISellOrderRepository sellOrderRepository, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _inventoryHttpClient = inventoryHttpClient;
            _sellOrderRepository = sellOrderRepository;
            _clientRepository = clientRepository;
        }

        public async Task<CreateSellOrderCommandResult> Handle(CreateSellOrderCommand command, CancellationToken cancellationToken)
        {
            var isClientExisting = await _clientRepository.AnyAsync(x => x.Id == command.ClientId, cancellationToken);
            if (!isClientExisting)
            {
                throw new ClientNotFoundException(command.ClientId);
            }
            var validateSellOrderQueryRequest = _mapper.Map<ValidateSellOrderQueryRequest>(command);

            var response = await _inventoryHttpClient.ValidateSellOrderAsync(validateSellOrderQueryRequest, cancellationToken);

            if (!response.IsValid)
            {
                var errors = new Dictionary<string, string[]>();

                if (response.NotFoundCompositeKeyInventories?.Count > 0)
                {
                    errors["NotFoundCompositeKeyInventories"] = response.NotFoundCompositeKeyInventories
                        .Select(n => $"ItemId: {n.CompositeKey.ItemId}, WarehouseId: {n.CompositeKey.WarehouseId}")
                        .ToArray();
                }

                if (response.InsufficientQuantityInventories?.Count > 0)
                {
                    errors["InsufficientQuantityInventories"] = response.InsufficientQuantityInventories
                        .Select(i => $"ItemId: {i.CompositeKey.ItemId}, WarehouseId: {i.CompositeKey.WarehouseId}, " +
                                     $"Requested: {i.RequestedQuantity}, Available: {i.AvailableQuantity}")
                        .ToArray();
                }

                throw new SellOrderInventoryValidationException(errors);
            }

            var sellOrder = _mapper.Map<SellOrder>(command);

            await _sellOrderRepository.AddAsync(sellOrder, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<CreateSellOrderCommandResult>(sellOrder);

            return result;
        }
    }
}
