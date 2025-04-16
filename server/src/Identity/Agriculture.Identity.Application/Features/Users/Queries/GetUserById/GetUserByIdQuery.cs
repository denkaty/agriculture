using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IQuery<GetUserByIdQueryResult>;
    
}
