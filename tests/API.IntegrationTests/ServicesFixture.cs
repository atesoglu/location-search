using System.IO;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.IntegrationTests
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
                .AddInfrastucture(configuration)
                .BuildServiceProvider();
        }
    }
}