using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService2.contracts;
using WorkerService2.utils;

namespace WorkerService2.services
{
    public class Email : IEmail
    {
        public void SendEmail(string to, string subject, string body)
        {
            var outlook = new EmailHelper("smtp.office365.com", "emailDeEnvioAqui", "SenhaDoEmailAq");
            outlook.SendEmail(new List<string> { to }, subject, body, new());
        }
    }
}
