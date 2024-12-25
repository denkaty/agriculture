using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Inventories.Commands.Transfer
{
    public class TransferCommandValidator : AbstractValidator<TransferCommand>
    {
        public TransferCommandValidator()
        {
            RuleFor(x => x.SourceWarehouseId)
                .NotEmpty().WithMessage("Source warehouse ID cannot be empty.");

            RuleFor(x => x.DestinationWarehouseId)
                .NotEmpty().WithMessage("Destination warehouse ID cannot be empty.");

            RuleFor(x => x)
                .Must(x => x.SourceWarehouseId != x.DestinationWarehouseId)
                .WithMessage("Source and destination warehouses cannot be the same.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Items collection cannot be empty.");

            RuleForEach(x => x.Items).ChildRules(items =>
            {
                items.RuleFor(i => i.ItemId)
                     .NotEmpty().WithMessage("Item ID cannot be empty.");

                items.RuleFor(i => i.Quantity)
                     .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            });
        }
    }
}
