using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Hangfire_Poc
{
    public static class Helper
    {
        public static string DefaultIfNull(string configKeyName, string defaultValue)
        {
            string configValue = string.IsNullOrWhiteSpace(configKeyName) ? null : ConfigurationManager.AppSettings?[configKeyName] ;
            return string.IsNullOrWhiteSpace(configValue) ? defaultValue : configValue;


        }
    }
}