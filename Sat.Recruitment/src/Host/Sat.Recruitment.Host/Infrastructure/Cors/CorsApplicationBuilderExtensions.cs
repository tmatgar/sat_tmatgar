using Microsoft.AspNetCore.Builder;

namespace Sat.Recruitment.Host.Infrastructure.Cors
{
    public static class CorsApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDevelopmentCors(this IApplicationBuilder app) =>
            app.UseCors(setup =>
                setup.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true)
            );
    }
}
