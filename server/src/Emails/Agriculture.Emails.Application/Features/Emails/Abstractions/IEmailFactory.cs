using System.Net.Mail;

namespace Agriculture.Emails.Application.Features.Emails.Abstractions
{
    public interface IEmailFactory
    {
        MailMessage GetEmail(string receiver, string subject, string template);
    }
}
