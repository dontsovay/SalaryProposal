using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SalaryProposal.Infrastructure.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalaryProposal.Infrastructure.Modules
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.UI.Services.IEmailSender" />
    public class AuthMessageSender : IEmailSender
    {
        /// <summary>Initializes a new instance of the <see cref="AuthMessageSender"/> class.</summary>
        /// <param name="optionsAccessor">The options accessor.</param>
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        /// <summary>Gets the options.</summary>
        /// <value>The options.</value>
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        /// <summary>This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        /// directly from your code. This API may change or be removed in future releases.</summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var Smtp = new SmtpClient(Options.Host, Options.Port)
            {
                Credentials = new NetworkCredential(Options.Address, Options.Password),
                EnableSsl = true
            })
            {
                var Message = new MailMessage { From = new MailAddress(Options.Address) };
                Message.To.Add(new MailAddress(email));
                Message.Subject = subject;
                Message.Body = htmlMessage;
                Message.BodyEncoding = System.Text.Encoding.UTF8;
                Message.IsBodyHtml = true;

                await Smtp.SendMailAsync(Message);
            }
        }
    }
}