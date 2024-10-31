using Agriculture.Identity.Application.Features.Users.Commands.Register;
using Agriculture.Identity.Contracts.Features.Users.Register;
using Agriculture.Identity.Web.Features.Users.Models.Requests;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Mappings
{
    public class RegisterCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterCommandRequest, RegisterCommand>();

            config.NewConfig<RegisterCommandResult, RegisterCommandResponse>();
        }
    }
}
