using FluentValidation;

namespace Agriculture.Transactions.Application.Features.Clients.Queries.GetClients
{
    public class GetClientsQueryValidator : AbstractValidator<GetClientsQuery>
    {
        public GetClientsQueryValidator()
        {
        }
    }
}
