using System.Net;
using System.Net.Mail;

namespace ECommerse.WebUI.Helper
{
    public class EmailConfrimation
    {
        public static void SendEmail(string link, string email)

        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("bayramlikenan920@gmail.com", "KenKen920920"),
                EnableSsl = true,
                UseDefaultCredentials = false
        };

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("bayramlikenan920@gmail.com");
            mail.To.Add(email);

            mail.Subject = $"www.nonawm.com::Email doğrulama";
            mail.Body = "<h2>Email adresinizi doğrulamak için lütfen aşağıdaki linke tıklayınız.</h2><hr/>";
            mail.Body += $"<a href='{link}'>email doğrulama linki</a>";
            mail.IsBodyHtml = true;


            smtpClient.Send(mail);
        }
    }
}
