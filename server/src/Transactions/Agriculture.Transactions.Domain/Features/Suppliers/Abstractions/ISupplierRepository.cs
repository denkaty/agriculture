using Agriculture.Shared.Domain.Abstractions;
using Agriculture.Transactions.Domain.Features.Suppliers.Models.Entities;

namespace Agriculture.Transactions.Domain.Features.Suppliers.Abstractions
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
    }
}
