using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;

[assembly: OwinStartup(typeof(Hangfire_Poc.Startup))]

namespace Hangfire_Poc
{
    public class Startup
    {
        //private IEnumerable<IDisposable> GetHangfireServers()
        //{
        //    GlobalConfiguration.Configuration
        //        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        //        .UseSimpleAssemblyNameTypeSerializer()
        //        .UseRecommendedSerializerSettings()
        //        .UseSqlServerStorage("Data Source=PANKAJTHAKUR\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True;", new SqlServerStorageOptions
        //        {
        //            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        //            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        //            QueuePollInterval = TimeSpan.Zero,
        //            UseRecommendedIsolationLevel = true,
        //            DisableGlobalLocks = true
        //        })
        //        //.WithJobExpirationTimeout(TimeSpan.FromHours(6))  sets the default expiration time after the job is completed 
        //        ;

        //    yield return new BackgroundJobServer();
        //}
        public void Configuration(IAppBuilder app)
        {
            EmailSender es = new EmailSender();
            //app.UseHangfireAspNet(GetHangfireServers);
            var options = new DashboardOptions
            {
                Authorization = new[]
            {
                new MyAuthorizationFilter()
                //LocalRequestsOnlyAuthorizationFilter() for local instance only    
            }
            };

        
            app.UseHangfireDashboard("/hangfire", options);
            //to set the schedule check interval time to 1 min , default is 15 sec
            //var options = new BackgroundJobServerOptions
            //{
            //    SchedulePollingInterval = TimeSpan.FromMinutes(1)
            //};
            //BackgroundJob.Schedule(
            //        () => Console.WriteLine("Hello, world"),
            //TimeSpan.FromDays(1));

            //var server = new BackgroundJobServer(options);
            // Let's also create a sample background job
            //BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //RecurringJob.AddOrUpdate("EmailSenderJobv2", () => es.SendEmail(), ConfigurationManager.AppSettings["CronValue"].ToString());
            RecurringJob.AddOrUpdate("EmailSenderJobName", () => es.SendEmail(), ConfigurationManager.AppSettings["CronValue"].ToString());

            if (Boolean.TryParse(ConfigurationManager.AppSettings["RemoveJob"].ToString(), out bool myBool))
            {
                //Removes the recurring job
                RecurringJob.RemoveIfExists(Helper.DefaultIfNull("EmailSenderJobName", "EmailSenderJob"));
            }
           
            
            
            


            //Trigger Existing job
            //RecurringJob.Trigger("some-id");
            //GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 10 });
        }
    }
    public class MyAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // In case you need an OWIN context, use the next line, `OwinContext` class
            // is the part of the `Microsoft.Owin` package.
            //var owinContext = new OwinContext(context.GetOwinEnvironment());

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            //return owinContext.Authentication.User.Identity.IsAuthenticated;
            return true;
        }
    }
}
