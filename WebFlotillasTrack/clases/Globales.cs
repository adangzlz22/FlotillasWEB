using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebFlotillasTrack.clases
{
    public class Globales
    {

        public static bool sendEmail(string subject, string msg, string emails)
        {
            bool result = true;
            try
            {
                var message = new MailMessage();
                    message.To.Add(new MailAddress(emails));
                string DE = "admin@lossaladitos.com";
                string PASS = "Tuj3f4ak0n.";
                message.Subject = subject;
                message.Body = msg;
                message.IsBodyHtml = true;
                message.From = new MailAddress(DE);
                System.Net.Mail.SmtpClient smtpMail = new System.Net.Mail.SmtpClient("igw18.site4now.net");
                smtpMail.EnableSsl = false;
                smtpMail.UseDefaultCredentials = false;
                smtpMail.Host = "mail.lossaladitos.com";
                smtpMail.Port = 8889;
                smtpMail.Credentials = new System.Net.NetworkCredential(DE, PASS);

                smtpMail.Send(message);
                smtpMail.Dispose();
            }
            catch (Exception e)
            {
                var exs = e.Message;
                result = false;
            }
            return result;
        }

    }
}