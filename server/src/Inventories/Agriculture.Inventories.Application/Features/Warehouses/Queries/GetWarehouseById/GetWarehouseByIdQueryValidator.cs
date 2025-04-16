using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Warehouses.Queries.GetWarehouseById
{
    public class GetWarehouseByIdQueryValidator : AbstractValidator<GetWarehouseByIdQuery>
    {
        public GetWarehouseByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
