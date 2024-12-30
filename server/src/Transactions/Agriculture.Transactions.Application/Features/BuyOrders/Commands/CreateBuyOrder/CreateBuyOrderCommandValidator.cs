using FluentValidation;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Commands.CreateBuyOrder
{
    public class CreateBuyOrderCommandValidator : AbstractValidator<CreateBuyOrderCommand>
    {
        public CreateBuyOrderCommandValidator()
        {
            RuleFor(x => x.SupplierId)
                .NotEmpty().WithMessage("Supplier ID is required.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("Status is required.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Items are required");
        }
    }
}
