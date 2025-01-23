using FluentValidation;

namespace Agriculture.Transactions.Application.Features.BuyOrders.Queries.GetBuyOrderById
{
    public class GetBuyOrderByIdQueryValidator : AbstractValidator<GetBuyOrderByIdQuery>
    {
        public GetBuyOrderByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
