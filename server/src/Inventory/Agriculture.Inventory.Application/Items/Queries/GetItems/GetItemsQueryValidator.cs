using FluentValidation;

namespace Agriculture.Inventory.Application.Items.Queries.GetItems
{
    public class GetItemsQueryValidator : AbstractValidator<GetItemsQuery>
    {
        public GetItemsQueryValidator()
        {
        }
    }
}
