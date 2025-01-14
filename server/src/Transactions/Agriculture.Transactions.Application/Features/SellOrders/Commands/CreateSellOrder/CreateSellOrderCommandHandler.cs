using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.Clients;
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
        private readonly ISellOrderRepository _sellOrderRepository;
        private readonly IClientRepository _clientRepository;

        public CreateSellOrderCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, ISellOrderRepository sellOrderRepository, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

            var sellOrder = _mapper.Map<SellOrder>(command);

            await _sellOrderRepository.AddAsync(sellOrder, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<CreateSellOrderCommandResult>(sellOrder);

            return result;
        }
    }
}
