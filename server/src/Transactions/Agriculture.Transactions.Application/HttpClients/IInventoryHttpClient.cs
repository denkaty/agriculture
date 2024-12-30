using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateBuyOrder;

namespace Agriculture.Transactions.Application.HttpClients
{
    public interface IInventoryHttpClient
    {
        Task<ValidateBuyOrderQueryResponse> ValidateBuyOrderAsync(ValidateBuyOrderQueryRequest request, CancellationToken cancellationToken);
    }
}
