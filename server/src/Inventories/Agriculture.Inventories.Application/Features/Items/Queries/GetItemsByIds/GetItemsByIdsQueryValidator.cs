using FluentValidation;

namespace Agriculture.Inventories.Application.Features.Items.Queries.GetItemsByIds
{
    public class GetItemsByIdsQueryValidator : AbstractValidator<GetItemsByIdsQuery>
    {
        public GetItemsByIdsQueryValidator()
        {
            RuleFor(x => x.Ids).NotEmpty();
        }
    }
}
