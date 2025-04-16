using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Common.Exceptions.Transactions.BuyOrders;
using Agriculture.Transactions.Domain.Features.BuyOrders.Abstractions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrders
{
    public class GetBuyOrdersQueryHandler : IRequestHandler<GetBuyOrdersQuery, GetBuyOrdersQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IBuyOrderRepository _buyOrderRepository;

        public GetBuyOrdersQueryHandler(IAgricultureMapper mapper, IBuyOrderRepository buyOrderRepository)
        {
            _mapper = mapper;
            _buyOrderRepository = buyOrderRepository;
        }

        public async Task<GetBuyOrdersQueryResult> Handle(GetBuyOrdersQuery request, CancellationToken cancellationToken)
        {
            var paginationList = await _buyOrderRepository.GetPaginatedAsync(cancellationToken, request.Page, request.PageSize, request.SortBy, request.SortOrder, request.SearchTerm);

            if (paginationList.Data.IsNullOrEmpty())
            {
                throw new BuyOrderEmptyCollectionException();
            }

            var result = _mapper.Map<GetBuyOrdersQueryResult>(paginationList);

            return result;
        }
    }
}
