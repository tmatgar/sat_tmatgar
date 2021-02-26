using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.Host;

namespace Sat.Recruitment.FunctionalTest.Config
{
    public static class HostServer
    {
        public static async Task<HttpClient> GetClient()
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables()
                        .Build();           

            var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {                 
                webHost.UseTestServer();
                webHost.UseConfiguration(config);
                webHost.UseStartup<Startup>();
            });          
            var host = await hostBuilder.StartAsync();

            var client = host.GetTestClient();

            return client;
        }
    }
}