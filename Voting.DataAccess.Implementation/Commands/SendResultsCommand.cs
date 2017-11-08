using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Voting.ViewModels;
using System.Net.Mail;

namespace Voting.DataAccess.Implementation.Commands
{
    public class SendResultsCommand : ISendResultsCommand
    {
        private readonly string _login;
        private readonly string _password;

        public SendResultsCommand(string smtpLogin, string smtpPassword)
        {
            _login = smtpLogin;
            _password = smtpPassword;
        }

        public async Task ExecuteAsync(UserResult result, IEnumerable<string> recievers)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_login, _password),
                EnableSsl = true
            };

            MailMessage message = new MailMessage {From = new MailAddress(_login)};

            foreach (var reciever in recievers)
            {
                message.To.Add(new MailAddress(reciever));
            }

            message.IsBodyHtml = true;
            message.Body = EmailMessageHelper.CreateMailMessage(result);

            await client.SendMailAsync(message);
        }
    }
}
