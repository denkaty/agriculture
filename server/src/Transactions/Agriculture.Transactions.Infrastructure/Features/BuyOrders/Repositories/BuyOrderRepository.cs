using Agriculture.Shared.Domain.Models.Pagination;
using Agriculture.Shared.Infrastructure.Persistences;
using Agriculture.Transactions.Domain.Features.BuyOrders.Abstractions;
using Agriculture.Transactions.Domain.Features.BuyOrders.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agriculture.Transactions.Infrastructure.Features.BuyOrders.Repositories
{
    public class BuyOrderRepository : Repository<BuyOrder>, IBuyOrderRepository
    {
        private readonly TransactionsContext _context;

        public BuyOrderRepository(TransactionsContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public override async Task<PaginationList<BuyOrder>> GetPaginatedAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10, string sortBy = "", string sortOrder = "asc", string searchTerm = "")
        {
            var query = _context.Set<BuyOrder>()
                                .Include(b => b.Supplier)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(buyOrder =>
                    buyOrder.Supplier.Name.Contains(searchTerm) ||
                    buyOrder.OrderDate.ToString().Contains(searchTerm));
            }

            Expression<Func<BuyOrder, object>> keySelector = sortBy.ToLower() switch
            {
                "supplierid" => buyOrder => buyOrder.SupplierId,
                "orderdate" => buyOrder => buyOrder.OrderDate,
                "totalamount" => buyOrder => buyOrder.TotalAmount,
                _ => buyOrder => buyOrder.OrderDate,
            };

            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(buyOrder => new BuyOrder
                                   {
                                       Id = buyOrder.Id,
                                       SupplierId = buyOrder.SupplierId,
                                       Supplier = buyOrder.Supplier,
                                       OrderDate = buyOrder.OrderDate,
                                       Items = buyOrder.Items,
                                       CreatedAt = buyOrder.CreatedAt,
                                       UpdatedAt = buyOrder.UpdatedAt,
                                   })
                                   .ToListAsync(cancellationToken);

            var paginationList = new PaginationList<BuyOrder>(data, page, pageSize, totalCount);

            return paginationList;
        }
    }
}
