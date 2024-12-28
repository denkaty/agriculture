using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Common.Exceptions.Transactions.Suppliers;
using Agriculture.Transactions.Domain.Features.Suppliers.Abstractions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Transactions.Application.Features.Suppliers.Queries.GetSuppliers
{
    public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, GetSuppliersQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetSuppliersQueryHandler(IAgricultureMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<GetSuppliersQueryResult> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var paginationList = await _supplierRepository.GetPaginatedAsync(cancellationToken, request.Page, request.PageSize, request.SortBy, request.SortOrder, request.SearchTerm);

            if (paginationList.Data.IsNullOrEmpty())
            {
                throw new SupplierEmptyCollectionException();
            }

            var result = _mapper.Map<GetSuppliersQueryResult>(paginationList);

            return result;
        }
    }
}
