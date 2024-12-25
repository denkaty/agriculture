using Agriculture.Inventories.Domain.Features.Items.Abstractions;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Inventories.Items;

namespace Agriculture.Inventories.Application.Features.Items.Commands.DeleteItemById
{
    public class DeleteItemByIdCommandHandler : ICommandHandler<DeleteItemByIdCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemByIdCommandHandler(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
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

            await _itemRepository.DeleteAsync(existingItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
