using ChatAll.Application.Interfaces;

namespace ChatAll.Infrastructure.Services
{
    // Implements the IEmailService interface
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
