using Agriculture.Shared.Common.Exceptions.Base;
using Agriculture.Shared.Common.Models.Options;
using Agriculture.Transactions.Application.HttpClients;
using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateBuyOrder;
using Agriculture.Transactions.Contracts.ExternalMicroservices.Features.Inventories.Inventories.Queries.ValidateSellOrder;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Agriculture.Transactions.Infrastructure.HttpClients
{
    public class InventoryHttpClient : IInventoryHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly InventoryHttpClientOptions _options;

        public InventoryHttpClient(IHttpClientFactory httpClientFactory, IOptions<InventoryHttpClientOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }

        public async Task<ValidateBuyOrderQueryResponse> ValidateBuyOrderAsync(ValidateBuyOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(_options.ClientName);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_options.AuthorizationScheme, "test");
            var requestUrl = $"{_options.BaseAddress}{_options.Endpoints["ValidateBuyOrder"]}";
            try
            {
                var response = await httpClient.PostAsJsonAsync(requestUrl, request, cancellationToken);

                var responseContent = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                var validationResponse = await response.Content.ReadFromJsonAsync<ValidateBuyOrderQueryResponse>(cancellationToken);

                return validationResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new BadRequestException("Error communicating with Inventory service", ex);
            }
            catch (JsonException ex)
            {
                throw new BadRequestException("Error deserializing response from Inventory service", ex);
            }
            catch (Exception ex)
            {
                throw new BadRequestException("An error occurred while validating the buy order", ex);
            }
        }

        public async Task<ValidateSellOrderQueryResponse> ValidateSellOrderAsync(ValidateSellOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(_options.ClientName);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_options.AuthorizationScheme, "test");
            var requestUrl = $"{_options.BaseAddress}{_options.Endpoints["ValidateSellOrder"]}";
            try
            {
                var response = await httpClient.PostAsJsonAsync(requestUrl, request, cancellationToken);

                var responseContent = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                var validationResponse = await response.Content.ReadFromJsonAsync<ValidateSellOrderQueryResponse>(cancellationToken);

                return validationResponse;
            }
            catch (HttpRequestException ex)
            {
                throw new BadRequestException("Error communicating with Inventory service", ex);
            }
            catch (JsonException ex)
            {
                throw new BadRequestException("Error deserializing response from Inventory service", ex);
            }
            catch (Exception ex)
            {
                throw new BadRequestException("An error occurred while validating the buy order", ex);
            }
        }
    }
}
