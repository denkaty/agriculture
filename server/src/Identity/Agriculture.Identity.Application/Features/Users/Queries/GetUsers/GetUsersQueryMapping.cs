using Agriculture.Identity.Application.Features.Users.Queries.GetUsers.Dtos;
using Agriculture.Identity.Contracts.Features.Users.Queries.GetUsers;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetUsersQueryRequest, GetUsersQuery>();

            config.NewConfig<(GetUsersQuery request, List<UserDto> users, int totalCount), GetUsersQueryResult>()
                .Map(dest => dest.Page, src => src.request.Page)
                .Map(dest => dest.PageSize, src => src.request.PageSize)
                .Map(dest => dest.TotalCount, src => src.totalCount)
                .Map(dest => dest.Items, src => src.users.Adapt<IReadOnlyCollection<GetUsersQueryViewModel>>());

            config.NewConfig<User, UserDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber);

            config.NewConfig<UserDto, GetUsersQueryViewModel>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
        }
    }
}
