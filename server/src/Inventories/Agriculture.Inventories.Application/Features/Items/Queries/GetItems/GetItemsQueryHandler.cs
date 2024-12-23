using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Common.Exceptions.Inventories.Items;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItems
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, GetItemsQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetItemsQueryHandler(IAgricultureMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<GetItemsQueryResult> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var paginationList = await _itemRepository.GetAllAsync(cancellationToken, request.Page, request.PageSize, request.SortBy, request.SortOrder, request.SearchTerm);

            if (paginationList.Data.IsNullOrEmpty())
            {
                throw new ItemEmptyCollectionException();
            }

            var result = _mapper.Map<GetItemsQueryResult>(paginationList);

            return result;
        }
    }
}
