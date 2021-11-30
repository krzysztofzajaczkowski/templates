using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WindowsServiceWorker.Configuration;

namespace WindowsServiceWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => 
                    builder.AddJsonFile("custom-config.json", false))
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<ApplicationOptions>(hostContext.Configuration.GetSection("Application"));
                    services.Configure<CustomOptions>(hostContext.Configuration.GetSection("Custom"));
                    services.AddHostedService<Worker>();
                });
    }
}
