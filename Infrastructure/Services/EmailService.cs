using ChatAll.Application.Interfaces;
using ChatAll.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace ChatAll.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var smtpServer = _configuration["Email:SmtpServer"];
                var smtpPortString = _configuration["Email:Port"];
                var username = _configuration["Email:Username"];
                var password = _configuration["Email:Password"];
                var fromEmail = _configuration["Email:FromEmail"];

                if (!int.TryParse(smtpPortString, out int smtpPort))
                {
                    _logger.LogError("Invalid SMTP Port in configuration: {Port}", smtpPortString);
                    return false;
                }



                using var client = new SmtpClient(smtpServer, smtpPort)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = true
                };

                using var message = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                message.To.Add(to);
                await client.SendMailAsync(message);
                _logger.LogInformation("Email sent successfully to {To}", to);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {To}", to);
                return false;
            }
        }

        public string GenerateRandomCode()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);


            string randomCode = "";

            for (int i = 0; i < 4; i++)
            {
                // Generare a random number
                var value = random.Next(0, 10);

                // Append the number to form the code
                randomCode += value.ToString();
            }

            return randomCode;
        }


    }

}
    
