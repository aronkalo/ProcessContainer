using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Container
{
    class Program
    {
        private static IConfigurationRoot _configuration;
        private static CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private static CancellationToken _cancellationToken = _tokenSource.Token;

        static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    _tokenSource.Cancel();
                };
                MainAsync(args).Wait();
                return 0;
            }
            catch
            {

                return 1;
            }
        }

        static async Task MainAsync(string[] args)
        {
            Log.Information("Creating service collection");
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Log.Information("Building service provider");
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            try
            {
                Log.Information("Starting service");
                await serviceProvider.GetService<App>().RunAsync(_cancellationToken);
                Log.Information("Ending service");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error running App service");
                throw;
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(LoggerFactory.Create(builder =>
            {
            }));

            serviceCollection.AddLogging();

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            //Register dependencies to the IoC container
            serviceCollection.AddSingleton<IConfiguration>(_configuration);
            serviceCollection.AddTransient<App>();
        }
    }
}
