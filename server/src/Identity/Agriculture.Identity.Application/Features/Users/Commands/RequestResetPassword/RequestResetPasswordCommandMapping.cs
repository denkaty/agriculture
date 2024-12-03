using Agriculture.Identity.Application.Features.Users.Models;
using Agriculture.Identity.Contracts.Features.Users.ResetPassword;
using Agriculture.Shared.Application.Events.Users;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Commands.RequestResetPassword
{
    public class RequestResetPasswordCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RequestResetPasswordCommandRequest, RequestResetPasswordCommand>();

            config.NewConfig<(RequestResetPasswordCommand Command, string Id), CreateResetPasswordTokenModel>()
                .Map(dest => dest.Email, src => src.Command.Email)
                .Map(dest => dest.UserId, src => src.Id);

            config.NewConfig<(string Email, string Url), UserRequestedResetPasswordEvent>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.RedirectUrl, src => src.Url);

        }
    }
}
