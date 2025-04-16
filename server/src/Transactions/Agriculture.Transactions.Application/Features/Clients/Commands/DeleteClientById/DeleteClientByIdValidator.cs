using FluentValidation;

namespace Agriculture.Transactions.Application.Features.Clients.Commands.DeleteClientById
{
    public class DeleteClientByIdValidator : AbstractValidator<DeleteClientByIdCommand>
    {
        public DeleteClientByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
