using System.Net;
using System.Net.Mail;
using Agriculture.Emails.Application.Features.Emails.Abstractions;
using Agriculture.Emails.Infrastructure.Features.Emails.Implementations;
using Agriculture.Emails.Infrastructure.Features.Emails.Models.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agriculture.Emails.Infrastructure.Features.Emails.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<EmailOptions>()
            .BindConfiguration(nameof(EmailOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var emailOptions = configuration
            .GetSection(nameof(EmailOptions))
            .Get<EmailOptions>()!;

        serviceCollection
            .AddScoped<IEmailFactory, EmailFactory>()
            .AddScoped<IEmailSender, EmailSender>();

        serviceCollection.AddScoped(_ => new SmtpClient()
        {
            Host = emailOptions.SmtpServer,
            Port = emailOptions.Port,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(emailOptions.Username, emailOptions.Password)
        });

        return serviceCollection;
    }
}
