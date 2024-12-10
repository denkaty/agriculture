using Agriculture.Inventory.Domain.Features.Items.Abstractions;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Items;

namespace Agriculture.Inventory.Application.Items.Commands.DeleteItemById
{
    public class DeleteItemByIdCommandHandler : ICommandHandler<DeleteItemByIdCommand>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemByIdCommandHandler(IAgricultureMapper mapper, IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteItemByIdCommand request, CancellationToken cancellationToken)
        {
            var existingItem = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingItem == null)
            {
                throw new ItemNotFoundException(request.Id);
            }

            _itemRepository.Delete(existingItem);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
