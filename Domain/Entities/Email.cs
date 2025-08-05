namespace ChatAll.Domain.Entities
{
    public class Email
    {

        public string SmtpServer { get; set; } = string.Empty;

        public int Port { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FromEmail { get; set; } = string.Empty;
    }
}
