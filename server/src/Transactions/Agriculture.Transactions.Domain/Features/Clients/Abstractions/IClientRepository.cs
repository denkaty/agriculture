using Agriculture.Shared.Domain.Abstractions;
using Agriculture.Transactions.Domain.Features.Clients.Models.Entities;

namespace Agriculture.Transactions.Domain.Features.Clients.Abstractions
{
    public interface IClientRepository : IRepository<Client>
    {
    }
}
