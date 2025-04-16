using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQueryValidator : AbstractValidator<GetItemByIdQuery>
    {
        public GetItemByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
