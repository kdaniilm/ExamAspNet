using ExamAspNet.Infrastructure.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly SendGridOptions _sendGridOptions;
        private readonly SendGridClient _sendGridClient;


        public EmailSender(SendGridOptions sendGridOptions)
        {
            this._sendGridOptions = sendGridOptions;
            this._sendGridClient = new SendGridClient(sendGridOptions.SendGridKey);
        }


        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridOptions.UserSender),
                Subject = subject,
                PlainTextContent = htmlMessage
            };
            message.AddTo(email);
            await _sendGridClient.SendEmailAsync(message);
        }
    }
}
