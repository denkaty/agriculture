using Agriculture.Shared.Domain.Models.Base;

namespace Agriculture.Transactions.Domain.Features.Clients.Models.Entities
{
    public class Client : Entity
    {
        public string TaxIdentificationNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
    }
}
