using FluentValidation;

namespace Agriculture.Items.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryValidator : AbstractValidator<GetItemByIdQuery>
    {
        public GetItemByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
