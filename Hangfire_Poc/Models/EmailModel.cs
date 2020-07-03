using System.Collections.Generic;

namespace Hangfire_Poc.Models
{
    public class EmailModel
    {
        public int Percentage
        {
            get
            {
                return (EmailsSent.Count * 100) / TotalEmails;
            }
        }
        public int TotalEmails { get; set; }
        public List<string> EmailsSent { get; set; } = new List<string>();
    }
}