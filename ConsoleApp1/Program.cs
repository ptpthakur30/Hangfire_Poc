using System;
using Hangfire;
using Hangfire.SqlServer;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Data Source=PANKAJTHAKUR\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });

            BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));

            using (var server = new BackgroundJobServer())
            {
                Console.ReadLine();
            }
        }
    }
}