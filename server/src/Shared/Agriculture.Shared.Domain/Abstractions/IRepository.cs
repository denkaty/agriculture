using Agriculture.Shared.Domain.Models.Base;
using Agriculture.Shared.Domain.Models.Pagination;
using System.Linq.Expressions;

namespace Agriculture.Shared.Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken);
        abstract Task<PaginationList<T>> GetAllAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "");
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
