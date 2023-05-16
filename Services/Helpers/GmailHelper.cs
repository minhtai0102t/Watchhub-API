using System;
using System.Net;
using System.Net.Mail;

namespace Ecom_API.Helpers;
public static class GmailHelper
{
    public static void SendVerificationEmail(string recipientEmail, string verificationCode)
    {
        // SMTP server details
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587; // or the appropriate port number
        string smtpUsername = "dh51904407@student.stu.edu.vn";
        string smtpPassword = "Minhtai@0102";

        // Sender email address and display name
        string senderEmail = "dh51904407@student.stu.edu.vn";
        string senderDisplayName = "Watchhub";

        // Create the email message
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(senderEmail, senderDisplayName);
        mail.To.Add(recipientEmail);
        mail.Subject = "Email Verification";
        mail.IsBodyHtml = true;

        // Construct the email body
        string verificationLink = "https://localhost:8383/Users/verify?code=" + verificationCode;
        string emailBody = $"Dear User,<br><br>" +
                           $"Thank you for signing up. Please click the link below to verify your email address:<br><br>" +
                           $"<a href='{verificationLink}'>Verification link</a><br><br>" +
                           $"If you did not sign up for our service, please ignore this email.<br><br>" +
                           $"Regards,<br>" +
                           $"Your Company";

        mail.Body = emailBody;
        // Create the SMTP client and configure it
        SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
        smtpClient.EnableSsl = true; // Set to true if your SMTP server requires SSL
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
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
    public static void SendLoginEmail(string recipientEmail)
    {
        // SMTP server details
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587; // or the appropriate port number
        string smtpUsername = "dh51904407@student.stu.edu.vn";
        string smtpPassword = "Minhtai@0102";

        // Sender email address and display name
        string senderEmail = "dh51904407@student.stu.edu.vn";
        string senderDisplayName = "Watchhub";

        // Create the email message
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(senderEmail, senderDisplayName);
        mail.To.Add(recipientEmail);
        mail.Subject = "Email Verification";
        mail.IsBodyHtml = true;

        // Construct the email body
        string loginLink = "watchhub.website";
        string emailBody = $"Dear User,<br><br>" +
                           $"Thank you for signing up. Please click the link below to verify your email address:<br><br>" +
                           $"<a href='{loginLink}'>Login Here</a><br><br>" +
                           $"If you did not sign up for our service, please ignore this email.<br><br>" +
                           $"Regards,<br>" +
                           $"Your Company";

        mail.Body = emailBody;
        // Create the SMTP client and configure it
        SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
        smtpClient.EnableSsl = true; // Set to true if your SMTP server requires SSL
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
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
