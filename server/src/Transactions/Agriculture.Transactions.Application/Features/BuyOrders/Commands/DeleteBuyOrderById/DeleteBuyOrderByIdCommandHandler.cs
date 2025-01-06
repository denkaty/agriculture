using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.BuyOrders;
using Agriculture.Transactions.Domain.Features.BuyOrders.Abstractions;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Commands.DeleteBuyOrderById
{
    public class DeleteBuyOrderByIdCommandHandler : ICommandHandler<DeleteBuyOrderByIdCommand>
    {
        private readonly IBuyOrderRepository _buyOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBuyOrderByIdCommandHandler(IBuyOrderRepository buyOrderRepository, IUnitOfWork unitOfWork)
        {
            _buyOrderRepository = buyOrderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteBuyOrderByIdCommand request, CancellationToken cancellationToken)
        {
            var existingBuyOrder = await _buyOrderRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingBuyOrder == null)
            {
                throw new BuyOrderNotFoundException(request.Id);
            }

            await _buyOrderRepository.DeleteAsync(existingBuyOrder, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
