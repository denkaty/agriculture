using FluentValidation;

namespace Agriculture.Transactions.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryValidator : AbstractValidator<GetSupplierByIdQuery>
    {
        public GetSupplierByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
