using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Sat.Recruitment.Host.Infrastructure.OpenApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenApi(this IServiceCollection services, IConfiguration configuration)
        {           
            return services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.CustomSchemaIds(schemaSelector => schemaSelector.FullName);
                options.OperationFilter<ApiVersionOperationFilter>();               

                var apiDescriptionProvider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var apiVersionDescription in apiDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        apiVersionDescription.GroupName,
                        new OpenApiInfo
                        {
                            Contact = new OpenApiContact { Email = HostConstants.EmailContact },
                            Version = apiVersionDescription.ApiVersion.ToString(),
                            Title = HostConstants.ApiTitle(apiVersionDescription.ApiVersion),
                            TermsOfService = null,
                            License = new OpenApiLicense(),
                            Description = apiVersionDescription.IsDeprecated
                                ? HostConstants.ApiDeprecatedMessage
                                : string.Empty
                        });
                }               
            });
        }
    }
}
