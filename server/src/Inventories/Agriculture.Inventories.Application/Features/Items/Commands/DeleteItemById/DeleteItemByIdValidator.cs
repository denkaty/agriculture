using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Items.Commands.DeleteItemById
{
    public class DeleteItemByIdValidator : AbstractValidator<DeleteItemByIdCommand>
    {
        public DeleteItemByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
