using Agriculture.Shared.Application.Abstractions.MediatR;

namespace Agriculture.Identity.Application.Features.Users.Queries.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, LoginQueryResult>
    {
        public async Task<LoginQueryResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return new LoginQueryResult(request.Email);
        }
    }
}
