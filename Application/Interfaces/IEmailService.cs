namespace ChatAll.Application.Interfaces
{

    // Defines what the email service should do but not how it should do it
    public interface IEmailService
    {

        // Async to send a email to verify the email address
        Task <bool>SendEmailAsync( string to, string subject, string body);

        public string GenerateRandomCode();
    }
}
