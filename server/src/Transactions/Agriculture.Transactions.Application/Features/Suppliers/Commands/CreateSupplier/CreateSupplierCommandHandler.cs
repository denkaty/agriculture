using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.Suppliers;
using Agriculture.Transactions.Domain.Features.Suppliers.Abstractions;
using Agriculture.Transactions.Domain.Features.Suppliers.Models.Entities;

namespace Agriculture.Transactions.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : ICommandHandler<CreateSupplierCommand, CreateSupplierCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
        }

        public async Task<CreateSupplierCommandResult> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
        {
            var isSupplierExisting = await _supplierRepository.AnyAsync(x => x.TaxIdentificationNumber == command.TaxIdentificationNumber, cancellationToken);
            if (isSupplierExisting)
            {
                throw new SupplierAlreadyExistsException(command.TaxIdentificationNumber);
            }

            var supplier = _mapper.Map<Supplier>(command);

            await _supplierRepository.AddAsync(supplier, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<CreateSupplierCommandResult>(supplier);

            return result;
        }
    }
}
