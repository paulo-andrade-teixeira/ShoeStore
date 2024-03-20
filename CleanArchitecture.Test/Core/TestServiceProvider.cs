using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistence.Services;

namespace CleanArchitecture.Tests.Core
{
    internal class TestServiceProvider
    {
        public readonly ServiceProvider ServiceProvider;
        public TestServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            var services = new ServiceCollection();
            services.ConfigurePersistenceApp(configuration);
            services.ConfigureApplicationApp();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
