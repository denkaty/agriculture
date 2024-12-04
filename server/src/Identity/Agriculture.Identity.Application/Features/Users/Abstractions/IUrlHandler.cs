namespace Agriculture.Identity.Application.Features.Users.Abstractions
{
    public interface IUrlHandler
    {
        string ConfigureResetPasswordUrl(string id, string token);
    }
}
