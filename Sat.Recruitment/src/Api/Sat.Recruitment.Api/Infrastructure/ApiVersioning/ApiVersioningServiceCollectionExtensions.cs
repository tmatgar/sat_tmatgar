using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Api.Infrastructure.ApiVersioning
{
    public static class ApiVersioningServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
        {
            return services
                .AddApiVersioning(setup =>
                {
                    setup.DefaultApiVersion = new ApiVersion(1, 0);
                    setup.AssumeDefaultVersionWhenUnspecified = true;
                    setup.ReportApiVersions = true;
                })
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "VVVV";
                });
        }
    }
}
