using System.Net.Mail;
using Agriculture.Emails.Application.Features.Emails.Abstractions;
using Agriculture.Emails.Infrastructure.Features.Emails.Models.Options;
using Microsoft.Extensions.Options;

namespace Agriculture.Emails.Infrastructure.Features.Emails.Implementations;

internal class EmailFactory : IEmailFactory
{
    private readonly EmailOptions _emailOptions;

    public EmailFactory(IOptions<EmailOptions> options)
    {
        _emailOptions = options.Value;
    }

    public MailMessage GetEmail(string receiver, string subject, string template)
    {
        return new MailMessage(_emailOptions.Sender, receiver, subject, template);
    }
}
