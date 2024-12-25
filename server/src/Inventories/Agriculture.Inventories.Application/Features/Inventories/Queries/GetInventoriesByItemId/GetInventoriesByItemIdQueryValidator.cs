using Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoryByItemId;
using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByItemId
{
    public class GetInventoriesByItemIdQueryValidator : AbstractValidator<GetInventoriesByItemIdQuery>
    {
        public GetInventoriesByItemIdQueryValidator()
        {
            RuleFor(x => x.ItemId).NotEmpty();
        }
    }
}
