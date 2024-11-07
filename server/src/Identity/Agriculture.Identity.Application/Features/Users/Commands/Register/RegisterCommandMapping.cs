using Agriculture.Identity.Contracts.Features.Users.Register;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Identity.Web.Features.Users.Models.Requests;
using Agriculture.Shared.Application.Events.Users;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Commands.Register
{
    public class RegisterCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterCommandRequest, RegisterCommand>();

            config.NewConfig<RegisterCommand, User>()
                .Map(dest => dest.Id, src => Guid.NewGuid().ToString())
                .Map(dest => dest.Email, src => src.Email.ToLower())
                .Map(dest => dest.UserName, src => src.Email.ToLower())
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber);

            config.NewConfig<User, RegisterCommandResult>()
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<User, UserCreatedEvent>();

            config.NewConfig<RegisterCommandResult, RegisterCommandResponse>();
        }
    }
}
