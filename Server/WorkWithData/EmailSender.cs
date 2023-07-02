using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace FitnessHelper
{
    internal class EmailSender
    {
        string email = "yourEmail@somemail.com";
        string password = "passwordOfYourEmail";

        public string Code { get; private set; }

        public EmailSender(string emailOfgetter, string subject)
        {
            Code = CreatingMessage();
            
            SendEmailAsync(emailOfgetter, subject, Code);
        }

        private async Task SendEmailAsync(string emailGetter, string subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("FitnessHelper", email));
            emailMessage.To.Add(MailboxAddress.Parse(emailGetter));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using (var client = new SmtpClient())
            {
                try
                {

                    await client.ConnectAsync("smtp.yandex.ru", 465, true); // Поменяйте хост или порт если требуется | change host or port if you need
                    await client.AuthenticateAsync(email, password);
                    await client.SendAsync(emailMessage);


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private static string CreatingMessage()
        {


            var rd = new Random();
            var listOfnum = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                int a = rd.Next(0, 9);

                listOfnum.Add(a.ToString());
            }

            string code = null;
            
            foreach (var i in listOfnum)
            {
                code += i;
            }


            return code;

        }

        


    }
}
