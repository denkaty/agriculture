using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Inventories.Items;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IQueryHandler<GetItemByIdQuery, GetItemByIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetItemByIdQueryHandler(IAgricultureMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<GetItemByIdQueryResult> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingItem == null)
            {
                throw new ItemNotFoundException(request.Id);
            }

            var result = _mapper.Map<GetItemByIdQueryResult>(existingItem);

            return result;
        }
    }
}
