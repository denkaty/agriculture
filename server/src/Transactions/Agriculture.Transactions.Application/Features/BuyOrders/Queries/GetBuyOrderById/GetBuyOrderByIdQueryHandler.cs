using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Transactions.BuyOrders;
using Agriculture.Transactions.Domain.Features.BuyOrders.Abstractions;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrderById
{
    public class GetBuyOrderByIdQueryHandler : IQueryHandler<GetBuyOrderByIdQuery, GetBuyOrderByIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IBuyOrderRepository _buyOrderRepository;

        public GetBuyOrderByIdQueryHandler(IAgricultureMapper mapper, IBuyOrderRepository buyOrderRepository)
        {
            _mapper = mapper;
            _buyOrderRepository = buyOrderRepository;
        }

        public async Task<GetBuyOrderByIdQueryResult> Handle(GetBuyOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var existingBuyOrder = await _buyOrderRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingBuyOrder == null)
            {
                throw new BuyOrderNotFoundException(request.Id);
            }

            var result = _mapper.Map<GetBuyOrderByIdQueryResult>(existingBuyOrder);

            return result;
        }
    }
}
