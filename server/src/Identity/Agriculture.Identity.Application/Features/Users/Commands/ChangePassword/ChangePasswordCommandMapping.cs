using Agriculture.Identity.Contracts.Features.Users.ChangePassword;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(ChangePasswordCommandRequest Request, string CurrentUserId), ChangePasswordCommand>()
                .Map(dest => dest.NewPassword, src => src.Request.NewPassword)
                .Map(dest => dest.ConfirmPassword, src => src.Request.ConfirmPassword)
                .Map(dest => dest.UserId, src => src.CurrentUserId);
        }
    }
}
