using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Host;

namespace Sat.Recruitment.FunctionalTest.Config
{
    public class TestServerBuilder
    {
        public TestServer Build()
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables()
                        .Build();

            var webHostBuilder = new WebHostBuilder()
                .UseTestServer()
                .UseConfiguration(config)
                .UseStartup<Startup>();

            return new TestServer(webHostBuilder);
        }
    }
}