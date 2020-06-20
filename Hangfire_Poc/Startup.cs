using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[assembly: OwinStartup(typeof(Hangfire_Poc.Startup))]

namespace Hangfire_Poc
{
    public class Startup
    {
        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Data Source=PANKAJTHAKUR\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                })
                //.WithJobExpirationTimeout(TimeSpan.FromHours(6))  sets the default expiration time after the job is completed 
                ;

            yield return new BackgroundJobServer();
        }
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireAspNet(GetHangfireServers);
            app.UseHangfireDashboard();
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
        }
    }
}
