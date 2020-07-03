using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace Hangfire_Poc
{
    public static class Helper
    {
        public static string DefaultIfNull(string configKeyName, string defaultValue)
        {
            string configValue = string.IsNullOrWhiteSpace(configKeyName) ? null : ConfigurationManager.AppSettings?[configKeyName] ;
            return string.IsNullOrWhiteSpace(configValue) ? defaultValue : configValue;
        }

        public static List<T> DatatableToList<T>(DataTable dt) where T:class,new()
        {
            List<T> list = new List<T>();
            T entity = new T();
            PropertyInfo[] PropInfo = entity.GetType().GetProperties();
            if(dt!=null && dt.Rows?.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var prop in PropInfo)
                    {
                        if(dt.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(entity, Convert.ChangeType(row[prop.Name],prop.PropertyType));
                        }
                    }
                    list.Add(entity);
                    entity = new T();
                }
            }
            return list;

        }
    }
}