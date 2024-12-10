using Agriculture.Shared.Domain.Abstractions;
using Agriculture.Shared.Domain.Models.Base;
using Agriculture.Shared.Domain.Models.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Shared.Infrastructure.Persistences
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContext _context;

        public Repository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public abstract Task<PaginationList<T>> GetAllAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "");

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AnyAsync(predicate, cancellationToken);
        }
    }

}
