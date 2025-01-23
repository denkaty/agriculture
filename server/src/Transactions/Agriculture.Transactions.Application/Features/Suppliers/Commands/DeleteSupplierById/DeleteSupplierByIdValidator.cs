using FluentValidation;

namespace Agriculture.Transactions.Application.Features.Suppliers.Commands.DeleteSupplierById
{
    public class DeleteSupplierByIdValidator : AbstractValidator<DeleteSupplierByIdCommand>
    {
        public DeleteSupplierByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
