using Agriculture.Identity.Application.Features.Users.Models;
using Agriculture.Identity.Contracts.Features.Users.Login;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Queries.Login
{
    public class LoginQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginQueryRequest, LoginQuery>();

            config.NewConfig<User, CreateAccessTokenModel>()
                 .Map(dest => dest.UserId, src => src.Id)
                 .Map(dest => dest.Email, src => src.Email)
                 .Map(dest => dest.FirstName, src => src.FirstName)
                 .Map(dest => dest.LastName, src => src.LastName);

            config.NewConfig<CreateAccessTokenResult, LoginQueryResult>();

            config.NewConfig<LoginQueryResult, LoginQueryResponse>();
        }
    }
}
