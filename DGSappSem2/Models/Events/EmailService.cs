using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DGSappSem2.Models.Events
{
    public class EmailService
    {

            private SmtpClient smtpClient;
            private const string Host = "Host", Port = "Port", EmailFrom = "EmailFrom", PassKey = "PassKey";
            protected MailAddress mailFrom { get; set; }
            public EmailService()
            {
                smtpClient = new SmtpClient(ConfigurationManager.AppSettings[Host], int.Parse(ConfigurationManager.AppSettings[Port]));
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings[EmailFrom], ConfigurationManager.AppSettings[PassKey]);
                mailFrom = new MailAddress(ConfigurationManager.AppSettings[EmailFrom], "Exporer Bookings");
            }
            public void SendEmail(EmailContent1 emailContent1)
            {
                MailMessage message = new MailMessage();
                message.From = mailFrom;
                foreach (MailAddress address in emailContent1.mailTo)
                    message.To.Add(address);
                foreach (MailAddress address in emailContent1.mailCc)
                    message.CC.Add(address);
                message.Subject = emailContent1.mailSubject;
                message.Priority = emailContent1.mailPriority;
                message.Body = emailContent1.mailBody + "<br/<br/>" + emailContent1.mailFooter;
                message.IsBodyHtml = true;
                foreach (Attachment attachment in emailContent1.mailAttachments)
                    message.Attachments.Add(attachment);

                try
                {
                    smtpClient.Send(message);
                }
                catch { }
            }
        }
        public class EmailContent1
        {
            public List<MailAddress> mailTo { get; set; }
            public List<MailAddress> mailCc { get; set; }
            public string mailSubject { get; set; }
            public string mailBody { get; set; }
            public string mailFooter { get; set; }
            public MailPriority mailPriority { get; set; }
            public List<Attachment> mailAttachments { get; set; }
        }
    
}