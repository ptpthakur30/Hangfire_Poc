using Hangfire_Poc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Hangfire_Poc
{
    public class EmailSender : System.Web.UI.Page
    {
        public async Task SendEmail()
        {
            Progress<EmailModel> progress = new Progress<EmailModel>();
            progress.ProgressChanged += DebugEmailProgress;
            CancellationTokenSource ctSource = new CancellationTokenSource();
            ctSource.Cancel();
            try
            {
                await SendEmailAsync(progress, ctSource.Token);
            }
            catch(OperationCanceledException ex)
            {
                Debug.WriteLine("Operation is cancelled"+ex.ToString());
            }
            
        }

        private void DebugEmailProgress(object sender, EmailModel e)
        {
             Debug.WriteLine($"The Emails Sent Percentage : {e.Percentage}%");
        }

        private async Task SendEmailAsync(IProgress<EmailModel> progress,CancellationToken token)
        {
            string emailReceivers = "ptpthakur30@gmail.com";
            //List<Task<bool>> lstEmail = new List<Task<bool>>();
            //foreach (var item in emailReceivers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //     token.ThrowIfCancellationRequested();
            //    lstEmail.Add(SendEmailAsync(item));
            //}
            //var result = await Task.WhenAll(lstEmail);
            List<string> EmailList = new List<string>(emailReceivers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            EmailModel emailModel = new EmailModel();
            emailModel.TotalEmails = EmailList.Count;
            token.ThrowIfCancellationRequested();
            //need some changes here
            await Task.Run(()=>Parallel.ForEach<string>(EmailList, email =>
             {
                 SendingEmailTo(email);
                 emailModel.EmailsSent.Add(email);
                 progress.Report(emailModel);
             }));

        }
        public bool SendingEmailTo(string receiverName)
        {
            //Fetching Settings from WEB.CONFIG file.  
            string emailSender = ConfigurationManager.AppSettings["emailsender"].ToString();
            string emailSenderPassword = ConfigurationManager.AppSettings["password"].ToString();
            string emailSenderHost = ConfigurationManager.AppSettings["smtpserver"].ToString();
            int emailSenderPort = Convert.ToInt16(ConfigurationManager.AppSettings["portnumber"]);
            Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);


            //Fetching Email Body Text from EmailTemplate File.  
            string FilePath = HostingEnvironment.MapPath(@"~\EmailTemplates\SignUp.html")?.ToString();
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            //Repalce [newusername] = signup user name   
            MailText = MailText.Replace("[newusername]", "Pankaj");


            string subject = "Welcome to CSharpCorner.Com";

            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress(emailSender);

            //Set To Email ID  
            _mailmsg.To.Add(receiverName);

            //Set Subject  
            _mailmsg.Subject = subject;

            //Set Body Text of Email   
            _mailmsg.Body = MailText;


            //Now set your SMTP   
            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            try
            {
                //Send Method will send your MailMessage create above.  
               _smtp.Send(_mailmsg);
               return  true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

    }
}