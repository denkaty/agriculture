using Agriculture.Identity.Contracts.Features.Users.ChangePassword;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(ChangePasswordCommandRequest Request, string CurrentUserId), ChangePasswordCommand>()
                .ConstructUsing(src => new(src.CurrentUserId, src.Request.ChangePasswordCommandBindingModel.NewPassword, src.Request.ChangePasswordCommandBindingModel.ConfirmPassword));
                
        }
    }
}
