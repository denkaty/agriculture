using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Inventories.Domain.Features.Items.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.Messaging;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Application.Events.Inventories.Items;
using Agriculture.Shared.Common.Exceptions.Inventories.Items;

namespace Agriculture.Inventories.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand, CreateItemCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;
        private readonly IItemRepository _itemRepository;

        public CreateItemCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _itemRepository = itemRepository;
        }

        public async Task<CreateItemCommandResult> Handle(CreateItemCommand command, CancellationToken cancellationToken)
        {
            var isItemExisting = await _itemRepository.AnyAsync(x => x.CatalogNumber == command.CatalogNumber, cancellationToken);
            if (isItemExisting)
            {
                throw new ItemAlreadyExistsException(command.CatalogNumber);
            }

            var item = _mapper.Map<Item>(command);

            await _itemRepository.AddAsync(item, cancellationToken);

            var itemCreatedEvent = _mapper.Map<ItemCreatedEvent>(item);

            await _eventPublisher.PublishAsync(itemCreatedEvent, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<CreateItemCommandResult>(item);

            return result;
        }
    }
}
