using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Inventories.Items;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemsByIds
{
    public class GetItemsByIdsQueryHandler : IQueryHandler<GetItemsByIdsQuery, GetItemsByIdsQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetItemsByIdsQueryHandler(IAgricultureMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<GetItemsByIdsQueryResult> Handle(GetItemsByIdsQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetByIdsAsync(request.Ids, cancellationToken);

            if (items.IsNullOrEmpty())
            { 
                throw new ItemEmptyCollectionException(); 
            }

            var result = _mapper.Map<GetItemsByIdsQueryResult>(items);

            return result;
        }
    }
}
