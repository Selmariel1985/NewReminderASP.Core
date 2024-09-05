using System.Net;
using System.Net.Mail;

/// <summary>
/// Class responsible for sending email notifications.
/// </summary>
public class EmailService
{
    /// <summary>
    /// Sends a confirmation email to the specified email address with a confirmation link.
    /// </summary>
    /// <param name="toAddress">The email address to send the confirmation email to.</param>
    /// <param name="confirmationUrl">The URL link for confirming the account.</param>
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

    /// <summary>
    /// Send an email notification about the change of email address to the specified user.
    /// </summary>
    /// <param name="userEmail">The email address of the user to notify about the email change.</param>
    public void SendEmailChangeNotification(string userEmail)
    {
        string subject = "Notification: Email Change";
        string body = "Dear User, \n\nThis is to inform you that your email address has been successfully updated. If you did not make this change, please contact our support team immediately. \n\nBest regards, \nYourApp Team";

        SendEmail(userEmail, subject, body);
    }

    /// <summary>
    /// Send a generic email with the specified subject and body to the specified email address.
    /// </summary>
    /// <param name="to">The email address to send the email to.</param>
    /// <param name="subject">The subject of the email.</param>
    /// <param name="body">The body content of the email.</param>
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