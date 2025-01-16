using FluentValidation;

namespace Agriculture.Transactions.Application.Features.SellOrders.Commands.CreateSellOrder
{
    public class CreateSellOrderCommandValidator : AbstractValidator<CreateSellOrderCommand>
    {
        public CreateSellOrderCommandValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Supplier ID is required.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("Status is required.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Items are required");
        }
    }
}
