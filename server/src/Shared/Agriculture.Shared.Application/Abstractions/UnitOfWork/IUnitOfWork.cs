using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Agriculture.Shared.Application.Abstractions.UnitOfWork
{
    //public interface IUnitOfWork<TDbContext> where TDbContext : DbContext
    //{
    //    DatabaseFacade Database { get; }

    //    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    //}
    public interface IUnitOfWork
    {
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
