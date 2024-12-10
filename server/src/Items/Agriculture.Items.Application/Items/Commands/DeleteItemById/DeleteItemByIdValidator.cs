using FluentValidation;

namespace Agriculture.Items.Application.Items.Commands.DeleteItemById
{
    public class DeleteItemByIdValidator : AbstractValidator<DeleteItemByIdCommand>
    {
        public DeleteItemByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
