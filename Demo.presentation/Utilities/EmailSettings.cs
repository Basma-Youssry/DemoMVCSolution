using System.Net;
using System.Net.Mail;

namespace Demo.presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.gmail.com", 587);

            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("basmayoussry5@gmail.com", "wqrayekentjauods");
            Client.Send("basmayoussry5@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
