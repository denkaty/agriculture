using Agriculture.Identity.Contracts.Features.Users.Queries.GetUserById;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetUserByIdQueryRequest, GetUserByIdQuery>();

            config.NewConfig<User, GetUserByIdQueryResult>();

            config.NewConfig<GetUserByIdQueryResult, GetUserByIdQueryResponse>();
        }
    }
}
