using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Common.Exceptions.Transactions.Clients;
using Agriculture.Transactions.Domain.Features.Clients.Abstractions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Agriculture.Transactions.Application.Features.Clients.Queries.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, GetClientsQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public GetClientsQueryHandler(IAgricultureMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<GetClientsQueryResult> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var paginationList = await _clientRepository.GetPaginatedAsync(cancellationToken, request.Page, request.PageSize, request.SortBy, request.SortOrder, request.SearchTerm);

            if (paginationList.Data.IsNullOrEmpty())
            {
                throw new ClientEmptyCollectionException();
            }

            var result = _mapper.Map<GetClientsQueryResult>(paginationList);

            return result;
        }
    }
}
