using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using TroubleInParadise.Services;

namespace WebPWrecover.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()//IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
           // Options = optionsAccessor.Value;
        }

        //public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            //return Execute(Options.SendGridKey, subject, message, email);
            return Execute(subject, message, email);
        }

        //public Task Execute(string apiKey, string subject, string message, string email)
        public Task Execute(string subject, string message, string email)
        {
            //var client = new SendGridClient("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");
            var client = new SendGridClient("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", "smtp.sendgrid.net");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("corneliusfrylinck@zohomail.com", "Trouble In Paradise Support"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}