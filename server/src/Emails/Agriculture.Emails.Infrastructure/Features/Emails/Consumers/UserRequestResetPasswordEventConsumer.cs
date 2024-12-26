using Agriculture.Emails.Application.Features.Emails.Abstractions;
using Agriculture.Emails.Infrastructure.Features.Emails.Utilities;
using Agriculture.Shared.Application.Events.Users;
using Agriculture.Shared.Common.Exceptions.Base;
using MassTransit;

namespace Agriculture.Emails.Infrastructure.Features.Emails.Consumers
{
    public class UserRequestResetPasswordEventConsumer : IConsumer<UserRequestResetPasswordEvent>
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IEmailSender _emailSender;

        public UserRequestResetPasswordEventConsumer(IEmailFactory emailFactory, IEmailSender emailSender)
        {
            _emailFactory = emailFactory;
            _emailSender = emailSender;
        }

        public async Task Consume(ConsumeContext<UserRequestResetPasswordEvent> context)
        {
            var emailContent = _emailFactory.GetEmail(context.Message.Email, EmailConstants.ForgotPasswordTitle, context.Message.RedirectUrl);

            try
            {
                await _emailSender.SendEmailAsync(emailContent, context.CancellationToken);
            }
            catch (Exception exception)
            {
                throw new BadRequestException(exception.Message, exception);
            }
        }
    }
}
