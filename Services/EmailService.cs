using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KCHitterDAD.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace KCHitterDAD.Services
{
    public class EmailService
    {
        public bool Send(string message)
        {
            var emailMessage = new MailMessage();
            emailMessage.To.Add(new MailAddress("KCHTest20171@gmail.com"));
            emailMessage.From = new MailAddress("KCHTest20171@gmail.com");
            emailMessage.Subject = "Contact Form Message";
            emailMessage.IsBodyHtml = true;
            emailMessage.Body = message;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "KCHTest20171@gmail.com",
                    Password = "KCHitters123"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(emailMessage);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}