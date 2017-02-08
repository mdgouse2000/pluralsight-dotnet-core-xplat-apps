
namespace CheckLinksConsole
{
    using System;
    using System.IO;
    using Hangfire;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            //var loggerFactory = host.Services.GetService<ILoggerFactory>();
            //loggerFactory.CreateLogger<Program>().LogInformation("test");
            var logger = host.Services.GetService<ILogger<Program>>();
            logger.LogInformation("logger indiretly");

            //RecurringJob.AddOrUpdate<CheckLinkJob>("check-link", j => j.Execute(config.Site, config.Output), Cron.Minutely);
            //RecurringJob.Trigger("check-link");
            RecurringJob.AddOrUpdate(() => Console.Write("Simple!"), Cron.Minutely);

            host.Run();
        }
    }
}
