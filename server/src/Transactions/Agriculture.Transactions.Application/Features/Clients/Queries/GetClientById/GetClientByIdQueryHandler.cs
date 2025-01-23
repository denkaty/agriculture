using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Transactions.Clients;
using Agriculture.Transactions.Domain.Features.Clients.Abstractions;

namespace Agriculture.Transactions.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, GetClientByIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public GetClientByIdQueryHandler(IAgricultureMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<GetClientByIdQueryResult> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var existingClient = await _clientRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingClient == null)
            {
                throw new ClientNotFoundException(request.Id);
            }

            var result = _mapper.Map<GetClientByIdQueryResult>(existingClient);

            return result;
        }
    }
}
