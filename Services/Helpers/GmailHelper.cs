using System.Net;
using System.Net.Mail;

namespace Ecom_API.Helpers;
public static class GmailHelper
{
    public static void SendVerificationEmail(string recipientEmail, string verificationCode)
    {
        // Create the email message
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(Constants.Gmail, Constants.GmailDisplayName);
        mail.To.Add(recipientEmail);
        mail.Subject = "Email Verification";
        mail.IsBodyHtml = true;

        // Construct the email body
        string verificationLink = Constants.VerificationLinkHosting;
        string emailBody = $"Dear User,<br><br>" +
                           $"Thank you for signing up. Please click the link below to verify your email address:<br><br>" +
                           $"Verification code= <h3><b>{verificationCode}</b></h3> expire in 10 minutes<br><br>" +
                           $"<a href='{verificationLink}'>Verification link</a><br><br>" +
                           $"If you did not sign up for our service, please ignore this email.<br><br>" +
                           $"Regards,<br>" +
                           $"{Constants.GmailDisplayName}";

        mail.Body = emailBody;
        // Create the SMTP client and configure it
        SmtpClient smtpClient = new SmtpClient(Constants.SMTP_SERVER, Constants.SMTP_PORT);
        smtpClient.EnableSsl = true; // Set to true if your SMTP server requires SSL
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(Constants.Gmail, Constants.AppPassword);
        try
        {
            // Send the email
            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
