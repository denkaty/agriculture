using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateSellOrder;

namespace Agriculture.Transactions.Application.HttpClients
{
    public interface IInventoryHttpClient
    {
        Task<ValidateBuyOrderQueryResponse> ValidateBuyOrderAsync(ValidateBuyOrderQueryRequest request, CancellationToken cancellationToken);
        Task<ValidateSellOrderQueryResponse> ValidateSellOrderAsync(ValidateSellOrderQueryRequest request, CancellationToken cancellationToken);
    }
}
