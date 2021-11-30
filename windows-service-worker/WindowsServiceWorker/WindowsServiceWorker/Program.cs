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
                {
                    // appsettings.json is added by default
                    builder.AddJsonFile("custom-config.json", false);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // Configure service provider for automatic dependency injection through constructors
                    
                    // Logger is registered by default

                    // Bind config sections to options classes and register them as IOptions<T>
                    services.Configure<ApplicationOptions>(hostContext.Configuration.GetSection("Application"));
                    services.Configure<CustomOptions>(hostContext.Configuration.GetSection("Custom"));

                    // Add background service that executes automatically
                    services.AddHostedService<Worker>();
                })
                .UseWindowsService();
    }
}
