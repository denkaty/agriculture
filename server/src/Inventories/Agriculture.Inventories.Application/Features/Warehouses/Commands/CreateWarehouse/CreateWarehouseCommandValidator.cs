using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Warehouses.Commands.CreateWarehouse
{
    public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
    {
        public CreateWarehouseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
        }
    }
}
