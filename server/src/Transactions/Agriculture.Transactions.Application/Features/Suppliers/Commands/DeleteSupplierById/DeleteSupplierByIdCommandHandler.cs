using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.Suppliers;
using Agriculture.Transactions.Domain.Features.Suppliers.Abstractions;

namespace Agriculture.Transactions.Application.Features.Suppliers.Commands.DeleteSupplierById
{
    public class DeleteSupplierByIdCommandHandler : ICommandHandler<DeleteSupplierByIdCommand>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierByIdCommandHandler(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteSupplierByIdCommand request, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingSupplier == null)
            {
                throw new SupplierNotFoundException(request.Id);
            }

            await _supplierRepository.DeleteAsync(existingSupplier, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
