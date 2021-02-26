using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Sat.Recruitment.Api.Infrastructure.ProblemDetailsExtensions
{
    public static class ProblemDetailsServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Title = "Validación de errores",
                        Detail = string.Empty
                    };
                    foreach (var error in problemDetails.Errors)
                    {
                        foreach (var errorDetail in error.Value)
                        {
                            problemDetails.Detail += string.Format("{0}{1}", errorDetail, ", ");
                        }
                    }
                    problemDetails.Detail = problemDetails.Detail.Substring(0, problemDetails.Detail.Length - 2);

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes =
                        {
                            "application/problem+json",
                            "application/problem+xml"
                        }
                    };
                };
            });

            return services.AddProblemDetails(config =>
            {
                config.ProblemDetailsMapConfiguration();
            });
        }
    }
}
