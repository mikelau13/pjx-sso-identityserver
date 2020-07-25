using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig ec;

        public string LocalDomain { get { return ec.LocalDomain; } }

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            this.ec = emailConfig.Value;
        }

        public async Task SendEmailAsync(String to, String subject, String message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.To.Add(new MailAddress(to));
                    mail.From = new MailAddress(ec.FromAddress, ec.FromName);
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    using (var client = new SmtpClient(ec.MailServerAddress))
                    {
                        client.Port = ec.MailServerPort;
                        client.Credentials = new NetworkCredential(ec.UserId, ec.UserPassword);
                        client.EnableSsl = true;
                        await client.SendMailAsync(mail).ConfigureAwait(false);
                        Console.WriteLine("SendEmailAsync succeed: " + subject);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendEmailAsync error: " + ex.Message);
            }
        }
    }
}
