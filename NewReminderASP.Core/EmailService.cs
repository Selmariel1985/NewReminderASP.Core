using System.Net;
using System.Net.Mail;

public class EmailService
{
    public void SendConfirmationEmail(string toAddress, string confirmationUrl)
    {
        using (var mail = new MailMessage())
        {
            mail.From = new MailAddress("Selmariel1985@yandex.by");
            mail.To.Add(toAddress);
            mail.Subject = "Confirmation Email";
            mail.Body = $"Please confirm your account by clicking this link: {confirmationUrl}";

            // Configure Yandex SMTP server settings
            using (var smtp = new SmtpClient("smtp.yandex.ru", 587))
            {
                smtp.Credentials = new NetworkCredential("Selmariel1985", "llrjmcwsqtakgzim");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
    }
}