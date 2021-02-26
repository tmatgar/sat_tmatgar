using Sat.Recruitment.Api;
using Sat.Recruitment.Host.Infrastructure.OpenApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Sat.Recruitment.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public IWebHostEnvironment Environment { get; set; }       

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services              
                .AddApiServices(Configuration, Environment)               
                .AddOpenApi(Configuration);
            }
            catch
            {
                throw;
            }            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                app.ConfigureApiPipeline(app => app
                    .UseDefaultFiles()
                    .UseStaticFiles()
                    .UseOpenApi(Configuration));
            }
            catch
            {
                throw;
            }            
        }
    }
}
