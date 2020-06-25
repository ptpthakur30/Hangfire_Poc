using Hangfire;
using Hangfire.SqlServer;
using System;
using System.Collections.Generic;
using System.Web.Hosting;

namespace Hangfire_Poc
{
    public class HangfireBootstrapper : IRegisteredObject
    {
        public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();

        private readonly object _lockObject = new object();
        private bool _started;

        //private BackgroundJobServer _backgroundJobServer;

        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                });
            //changes the default check intervals of scheduling job default is 15 sec 
            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromMinutes(1)
            };
            
            yield return new BackgroundJobServer(options);
        }
        private HangfireBootstrapper()
        {
        }

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started)
                {
                    return;
                }

                _started = true;

                HostingEnvironment.RegisterObject(this);

                //GlobalConfiguration.Configuration
                //    .UseSqlServerStorage(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //// Specify other options here

                //_backgroundJobServer = new BackgroundJobServer();
                HangfireAspNet.Use(GetHangfireServers);

            }
        }

        public void Stop()
        {
            lock (_lockObject)
            {
                //if (_backgroundJobServer != null)
                //{
                //    _backgroundJobServer.Dispose();
                //}

                HostingEnvironment.UnregisterObject(this);
            }
        }

        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }
    }
}