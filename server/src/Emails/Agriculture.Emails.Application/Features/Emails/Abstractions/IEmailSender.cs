using System.Net.Mail;

namespace Agriculture.Emails.Application.Features.Emails.Abstractions
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MailMessage mailMessage, CancellationToken cancellationToken);
    }
}
