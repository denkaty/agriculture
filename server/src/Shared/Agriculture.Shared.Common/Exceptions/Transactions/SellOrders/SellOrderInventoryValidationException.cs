using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Transactions.SellOrders
{
    public class SellOrderInventoryValidationException : ValidationException
    {
        public SellOrderInventoryValidationException(IDictionary<string, string[]> errors)
            : base(errors)
        {
        }
    }
}