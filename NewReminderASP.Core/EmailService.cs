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

            using (var smtp = new SmtpClient("smtp.yandex.ru", 587))
            {
                smtp.Credentials = new NetworkCredential("Selmariel1985", "llrjmcwsqtakgzim");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
    }

    public void SendEmailChangeNotification(string userEmail)
    {
        string subject = "Notification: Email Change";
        string body = "Dear User, \n\nThis is to inform you that your email address has been successfully updated. If you did not make this change, please contact our support team immediately. \n\nBest regards, \nYourApp Team";

        SendEmail(userEmail, subject, body);
    }

    private void SendEmail(string to, string subject, string body)
    {
        using (var mail = new MailMessage())
        {
            mail.From = new MailAddress("Selmariel1985@yandex.by");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            using (var smtp = new SmtpClient("smtp.yandex.ru", 587))
            {
                smtp.Credentials = new NetworkCredential("Selmariel1985", "llrjmcwsqtakgzim");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
    }
}
