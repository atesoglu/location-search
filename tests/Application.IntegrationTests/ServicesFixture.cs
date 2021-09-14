using System.IO;
using Application.IntegrationTests.Services;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IntegrationTests
{
    public class ServicesFixture
    {
        public readonly ServiceProvider ServiceProvider;

        public ServicesFixture()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appSettings.Test.json", optional: false, reloadOnChange: true)
                .Build();

            ServiceProvider = new ServiceCollection()
                .AddLogging()
                .AddApplication(configuration)
                .AddScoped<IEventDispatcherService, EmptyEventDispatcherService>()
                .BuildServiceProvider();
        }
    }
}