using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.Clients;
using Agriculture.Transactions.Domain.Features.Clients.Abstractions;
using Agriculture.Transactions.Domain.Features.Clients.Models.Entities;
using MediatR;

namespace Agriculture.Transactions.Application.Features.Clients.Commands
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientCommandResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IAgricultureMapper mapper, IUnitOfWork unitOfWork, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _clientRepository = clientRepository;
        }

        public async Task<CreateClientCommandResult> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var isClientExisting = await _clientRepository.AnyAsync(x => x.TaxIdentificationNumber == command.TaxIdentificationNumber, cancellationToken);
            if (isClientExisting)
            {
                throw new ClientAlreadyExistsException(command.TaxIdentificationNumber);
            }

            var client = _mapper.Map<Client>(command);

            await _clientRepository.AddAsync(client, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<CreateClientCommandResult>(client);

            return result;
        }
    }
}
