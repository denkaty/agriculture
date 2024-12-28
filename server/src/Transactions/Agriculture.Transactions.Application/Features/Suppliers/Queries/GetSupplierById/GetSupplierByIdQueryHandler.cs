using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Transactions.Suppliers;
using Agriculture.Transactions.Domain.Features.Suppliers.Abstractions;

namespace Agriculture.Transactions.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IQueryHandler<GetSupplierByIdQuery, GetSupplierByIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierByIdQueryHandler(IAgricultureMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<GetSupplierByIdQueryResult> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingSupplier == null)
            {
                throw new SupplierNotFoundException(request.Id);
            }

            var result = _mapper.Map<GetSupplierByIdQueryResult>(existingSupplier);

            return result;
        }
    }
}
