using Agriculture.Shared.Domain.Models.Pagination;
using Agriculture.Shared.Infrastructure.Persistences;
using Agriculture.Transactions.Domain.Features.Clients.Abstractions;
using Agriculture.Transactions.Domain.Features.Clients.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Transactions.Infrastructure.Features.Clients.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly TransactionsContext _context;

        public ClientRepository(TransactionsContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public override async Task<PaginationList<Client>> GetPaginatedAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<Client>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(client =>
                    client.TaxIdentificationNumber.Contains(searchTerm) ||
                    client.Name.Contains(searchTerm) ||
                    client.Email.Contains(searchTerm) ||
                    client.PhoneNumber.Contains(searchTerm) ||
                    client.Address.Contains(searchTerm) ||
                    (client.ContactPerson != null && client.ContactPerson.Contains(searchTerm)));
            }

            Expression<Func<Client, object>> keySelector = sortBy.ToLower() switch
            {
                "taxidentificationnumber" => client => client.TaxIdentificationNumber,
                "name" => client => client.Name,
                "email" => client => client.Email,
                "phonenumber" => client => client.PhoneNumber,
                "address" => client => client.Address,
                "contactperson" => client => client.ContactPerson,
                _ => client => client.TaxIdentificationNumber,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(client => new Client
                                   {
                                       Id = client.Id,
                                       TaxIdentificationNumber = client.TaxIdentificationNumber,
                                       Name = client.Name,
                                       Email = client.Email,
                                       PhoneNumber = client.PhoneNumber,
                                       Address = client.Address,
                                       ContactPerson = client.ContactPerson,
                                       CreatedAt = client.CreatedAt,
                                       UpdatedAt = client.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<Client>(data, page, pageSize, totalCount);

            return paginationList;
        }
    }
}
