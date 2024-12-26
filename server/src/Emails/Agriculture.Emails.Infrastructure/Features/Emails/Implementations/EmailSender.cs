using Agriculture.Emails.Application.Features.Emails.Abstractions;
using System.Net.Mail;

namespace Agriculture.Emails.Infrastructure.Features.Emails.Implementations;

internal class EmailSender : IEmailSender
{
    private readonly SmtpClient _smtpClient;

    public EmailSender(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public async Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken)
    {
        await _smtpClient.SendMailAsync(mailMessage, cancellationToken);
    }
}
