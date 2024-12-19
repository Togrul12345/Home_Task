using System.Net;
using System.Net.Mail;

namespace PurpleBuzzTask.Utilities
{
    public class EmailService
    {
        IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public void Send(string sendTo)
        {
            SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);
            MailAddress from = new MailAddress("togrultb-ab205@code.edu.az");
            MailAddress to = new MailAddress(sendTo);
            MailMessage message = new MailMessage(from,to);
            message.IsBodyHtml = true;
            message.Subject = "from Purple buzz";
            message.Body = "salam necesen?";
            smtp.Send(message);
        }
    }
}
