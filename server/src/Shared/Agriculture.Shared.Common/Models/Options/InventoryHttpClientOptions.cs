namespace Agriculture.Shared.Common.Models.Options
{
    public class InventoryHttpClientOptions
    {
        public string ClientName {  get; set; } = string.Empty;
        public string BaseAddress { get; set; } = string.Empty;
        public string AcceptJsonHeader { get; set; } = string.Empty;
        public string AuthorizationScheme {  get; set; } = string.Empty;
        public Dictionary<string, string> Endpoints { get; set; } = new Dictionary<string, string>();
    }
}
