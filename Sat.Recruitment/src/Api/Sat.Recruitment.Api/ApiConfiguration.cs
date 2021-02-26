using Hellang.Middleware.ProblemDetails;
using Sat.Recruitment.Api.Infrastructure.ApiVersioning;
using Sat.Recruitment.Api.Infrastructure.Extensions;
using Sat.Recruitment.Api.Infrastructure.FluentValidations;
using Sat.Recruitment.Api.Infrastructure.ProblemDetailsExtensions;
using Sat.Recruitment.Domain.Core.Settings;
using Sat.Recruitment.Domain.Core.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace Sat.Recruitment.Api
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            try
            {
                services
                    .Configure<SatConfigurationSettings>(configuration)
                    .AddScoped<UserContext>()
                    .AddCustomApiVersioning()
                    .AddApplicationServices()
                    .AddCustomProblemDetails(environment)
                    .AddCors(options =>
                    {
                        options.AddPolicy("CorsPolicy",
                            builder => builder
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .SetIsOriginAllowed(origin => true) //Allow any origin
                                .AllowCredentials());
                    });

                return services
                    .AddControllers()
                    .AddCustomFluentValidations()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    }).Services;
            }
            catch
            {
                throw;
            }
        }

        public static void ConfigureApiPipeline(this IApplicationBuilder app,
            Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            try
            {
                configureHost(app)
                .UseRouting()
                .UseCors("CorsPolicy")
                .UseProblemDetails()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
            catch
            {
                throw;
            }
        }
    }
}