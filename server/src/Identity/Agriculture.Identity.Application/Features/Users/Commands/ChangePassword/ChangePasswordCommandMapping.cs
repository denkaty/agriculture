using Agriculture.Identity.Contracts.Features.Users.Commands.ChangePassword;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ChangePasswordCommandRequest, ChangePasswordCommand>()
                .ConstructUsing(src => new(src.CurrentUserId, src.ChangePasswordCommandBindingModel.NewPassword, src.ChangePasswordCommandBindingModel.ConfirmPassword));
                
        }
    }
}
