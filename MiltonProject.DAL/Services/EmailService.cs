using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using MiltonProject.DAL.Interfaces;

namespace MiltonProject.DAL.Services
{
    public class EmailService : IEmailService
    {
        void EmailSender(string email, string body, string title)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("miltonbillingservice@gmail.com", "billing1234"),
                EnableSsl = true,
            };

            smtpClient.Send("miltonbillingservice@gmail.com", email, title, body);
        }

        void IEmailService.EmailSender(string email, string body, string title)
        {
            EmailSender(email, body, title);
        }
    }
}
