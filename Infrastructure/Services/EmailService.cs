using ChatAll.Application.Interfaces;
using ChatAll.Domain.Entities;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;


namespace ChatAll.Infrastructure.Services
{
    // Implements the IEmailService interface
    public class EmailService : IEmailService
    {

        private readonly Email _email;
        private readonly ILogger<EmailService> _logger;

       
        public EmailService(IOptions<Email> email, ILogger<EmailService> logger)
        {
            _email = email.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body)
        {

            try
            {
                using var client = new SmtpClient(_email.SmtpServer, _email.SmtpPort)
                {
                    Credentials = new NetworkCredential(_email.Usermame, _email.Password),
                    EnableSsl = true
                };


                using var message = new MailMessage
                {
                    From = new MailAddress(_email.FromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                message.To.Add(to);


                await client.SendMailAsync(message);

                _logger.LogInformation("Email sent successfully to {To}", to);
                return true;
            }

            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {To}", to);
                return false;
            }
        }
    }
}
