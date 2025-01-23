using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Common.Exceptions.Transactions.Clients;
using Agriculture.Transactions.Domain.Features.Clients.Abstractions;

namespace Agriculture.Transactions.Application.Features.Clients.Commands.DeleteClientById
{
    public class DeleteClientByIdCommandHandler : ICommandHandler<DeleteClientByIdCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientByIdCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteClientByIdCommand request, CancellationToken cancellationToken)
        {
            var existingClient = await _clientRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingClient == null)
            {
                throw new ClientNotFoundException(request.Id);
            }

            await _clientRepository.DeleteAsync(existingClient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
