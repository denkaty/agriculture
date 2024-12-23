using Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByItemId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agriculture.Inventories.Contracts.Features.Inventories.Queries.GetInventoryByWarehouseId
{
    public class GetInventoriesByWarehouseIdQueryResponse
    {
        public IReadOnlyCollection<GetInventoriesByWarehouseIdQueryViewModel> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
