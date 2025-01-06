using FluentValidation;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Commands.DeleteBuyOrderById
{
    public class DeleteBuyOrderByIdValidator : AbstractValidator<DeleteBuyOrderByIdCommand>
    {
        public DeleteBuyOrderByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
