using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Infrastructure.Logs
{
    public class LoggerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
        {
            this._logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _logger.LogInformation($"{JsonSerializer.Serialize(request)}");
                var response = await next();
                _logger.LogInformation($"{JsonSerializer.Serialize(response)}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Exception : {ex.Message} StackTrace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
