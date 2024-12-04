using Agriculture.Identity.Contracts.Features.Users.Commands.ResetPassword;
using Mapster;

namespace Agriculture.Identity.Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ResetPasswordCommandRequest, ResetPasswordCommand>()
                .ConstructUsing(src => new(src.ResetPasswordCommandBindingModel.UserId, src.ResetPasswordCommandBindingModel.Token, src.ResetPasswordCommandBindingModel.NewPassword, src.ResetPasswordCommandBindingModel.ConfirmPassword));
        }
    }
}
