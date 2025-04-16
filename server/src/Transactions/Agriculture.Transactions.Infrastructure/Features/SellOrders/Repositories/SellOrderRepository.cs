using Agriculture.Shared.Domain.Models.Pagination;
using Agriculture.Shared.Infrastructure.Persistences;
using Agriculture.Transactions.Domain.Features.SellOrders.Abstractions;
using Agriculture.Transactions.Domain.Features.SellOrders.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Transactions.Infrastructure.Features.SellOrders.Repositories
{
    public class SellOrderRepository : Repository<SellOrder>, ISellOrderRepository
    {
        private readonly TransactionsContext _context;

        public SellOrderRepository(TransactionsContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public override async Task<SellOrder?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.SellOrders
                .Include(s => s.Client)
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public override async Task<PaginationList<SellOrder>> GetPaginatedAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<SellOrder>()
                                .Include(s => s.Client)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(sellOrder =>
                    sellOrder.Client.Name.Contains(searchTerm) ||
                    sellOrder.OrderDate.ToString().Contains(searchTerm));
            }

            Expression<Func<SellOrder, object>> keySelector = sortBy.ToLower() switch
            {
                "clientid" => sellOrder => sellOrder.ClientId,
                "orderdate" => sellOrder => sellOrder.OrderDate,
                "totalamount" => sellOrder => sellOrder.TotalAmount,
                _ => sellOrder => sellOrder.OrderDate,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(sellOrder => new SellOrder
                                   {
                                       Id = sellOrder.Id,
                                       ClientId = sellOrder.ClientId,
                                       Client = sellOrder.Client,
                                       OrderDate = sellOrder.OrderDate,
                                       Items = sellOrder.Items,
                                       TotalAmount = sellOrder.TotalAmount,
                                       CreatedAt = sellOrder.CreatedAt,
                                       UpdatedAt = sellOrder.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<SellOrder>(data, page, pageSize, totalCount);

            return paginationList;
        }
    }
}
