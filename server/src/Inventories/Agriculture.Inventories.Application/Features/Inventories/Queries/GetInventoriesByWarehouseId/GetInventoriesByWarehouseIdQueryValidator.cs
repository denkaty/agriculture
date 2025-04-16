using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Inventories.Queries.GetInventoriesByWarehouseId
{
    public class GetInventoriesByWarehouseIdQueryValidator : AbstractValidator<GetInventoriesByWarehouseIdQuery>
    {
        public GetInventoriesByWarehouseIdQueryValidator()
        {
            RuleFor(x => x.WarehouseId).NotEmpty();
        }
    }
}
