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

            config.NewConfig<(User User, string[] Roles), CreateAccessTokenModel>()
                 .Map(dest => dest.UserId, src => src.User.Id)
                 .Map(dest => dest.Email, src => src.User.Email)
                 .Map(dest => dest.FirstName, src => src.User.FirstName)
                 .Map(dest => dest.LastName, src => src.User.LastName)
                 .Map(dest => dest.Roles, src => src.Roles);

            config.NewConfig<CreateAccessTokenResult, LoginQueryResult>();

            config.NewConfig<LoginQueryResult, LoginQueryResponse>();
        }
    }
}
