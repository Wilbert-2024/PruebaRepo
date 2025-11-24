namespace MartinWilbert.Services
{
    public interface IEmailService
    {
        void SendPasswordResetEmail(string toEmail, string body);
    }
}
