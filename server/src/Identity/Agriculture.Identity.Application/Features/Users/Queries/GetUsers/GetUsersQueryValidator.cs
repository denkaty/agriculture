using FluentValidation;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
        }
    }
}
