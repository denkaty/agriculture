using FluentValidation;

namespace Agriculture.Transactions.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryValidator : AbstractValidator<GetClientByIdQuery>
    {
        public GetClientByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
