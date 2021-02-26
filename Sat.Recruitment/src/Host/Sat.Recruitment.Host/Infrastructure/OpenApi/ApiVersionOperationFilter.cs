using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Host.Infrastructure.OpenApi
{
    public class ApiVersionOperationFilter : IOperationFilter
    {
        private const string _apiVersionParam = "api-version";
        private const string _apiVersionDescription = "The requested API version";

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiVersion = context.ApiDescription.GetApiVersion();
            if (apiVersion == null)
            {
                return;
            }

            var parameters = operation.Parameters;
            if (parameters == null)
            {
                operation.Parameters = parameters = new List<OpenApiParameter>();
            }

            var parameter = parameters.FirstOrDefault(p => p.Name == _apiVersionParam);
            if (parameter == null)
            {
                parameter = new OpenApiParameter()
                {
                    Name = _apiVersionParam,
                    Required = true,
                    In = ParameterLocation.Query,
                    Description = _apiVersionDescription,
                    Schema = new OpenApiSchema
                    {
                        Default = new OpenApiString(apiVersion.ToString()),
                        Type = nameof(String)
                    }
                };
                parameters.Add(parameter);
            }
            else if (parameter is OpenApiParameter pathParameter)
            {
                parameter.Schema.Default = new OpenApiString(apiVersion.ToString());
            }

            parameter.Description = _apiVersionDescription;
        }
    }
}
