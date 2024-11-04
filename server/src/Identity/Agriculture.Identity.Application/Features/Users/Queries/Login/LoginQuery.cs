using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Queries.Login
{
    public record LoginQuery(string Email) : IQuery<LoginQueryResult>;
   
}
