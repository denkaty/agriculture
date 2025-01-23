using Agriculture.Shared.Domain.Models.Pagination;
using Agriculture.Shared.Infrastructure.Persistences;
using Agriculture.Transactions.Domain.Features.Suppliers.Abstractions;
using Agriculture.Transactions.Domain.Features.Suppliers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Transactions.Infrastructure.Features.Suppliers.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly TransactionsContext _context;
        public SupplierRepository(TransactionsContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public override async Task<PaginationList<Supplier>> GetPaginatedAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<Supplier>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(supplier =>
                    supplier.TaxIdentificationNumber.Contains(searchTerm) ||
                    supplier.Name.Contains(searchTerm) ||
                    supplier.Email.Contains(searchTerm) ||
                    supplier.PhoneNumber.Contains(searchTerm) ||
                    supplier.Address.Contains(searchTerm) ||
                    (supplier.ContactPerson != null && supplier.ContactPerson.Contains(searchTerm)));
            }

            Expression<Func<Supplier, object>> keySelector = sortBy.ToLower() switch
            {
                "taxidentificationnumber" => supplier => supplier.TaxIdentificationNumber,
                "name" => supplier => supplier.Name,
                "email" => supplier => supplier.Email,
                "phonenumber" => supplier => supplier.PhoneNumber,
                "address" => supplier => supplier.Address,
                "contactperson" => supplier => supplier.ContactPerson,
                _ => supplier => supplier.TaxIdentificationNumber,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(supplier => new Supplier
                                   {
                                       Id = supplier.Id,
                                       TaxIdentificationNumber = supplier.TaxIdentificationNumber,
                                       Name = supplier.Name,
                                       Email = supplier.Email,
                                       PhoneNumber = supplier.PhoneNumber,
                                       Address = supplier.Address,
                                       ContactPerson = supplier.ContactPerson,
                                       CreatedAt = supplier.CreatedAt,
                                       UpdatedAt = supplier.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<Supplier>(data, page, pageSize, totalCount);

            return paginationList;
        }
    }
}
