using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;

namespace Sat.Recruitment.Host.Infrastructure.OpenApi
{
    public static class OpenApiAplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, IConfiguration configuration)
        {            
            return app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    var apiDescriptionProvider = app.ApplicationServices.GetService(typeof(IApiVersionDescriptionProvider)) as IApiVersionDescriptionProvider;
                    if (apiDescriptionProvider != null)
                    {
                        foreach (var apiVersionDescription in apiDescriptionProvider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint(
                                $"/swagger/{apiVersionDescription.GroupName}/swagger.json",
                                $"Version {apiVersionDescription.ApiVersion}"
                            );
                        }
                    }
                    else
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/swagger.json",
                            $"Version 1.0"
                        );
                    }                   
                });
        }
    }
}
