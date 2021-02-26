using Sat.Recruitment.Api.Infrastructure.Logs;
using Sat.Recruitment.Infrastructure.Statements;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Business.Users;
using Sat.Recruitment.Domain.Core.Entities;
using Sat.Recruitment.Infrastructure.Data;
using Sat.Recruitment.Domain.Core.Interfaces;

namespace Sat.Recruitment.Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(CreateUserHandler).Assembly)                
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>))
                .Scan(scrutor => scrutor
                    .FromAssembliesOf(
                        typeof(CreateUserHandler),
                        typeof(Register)
                    )
                    .AddClasses(classes => classes.InNamespaceOf(
                        typeof(CreateUserHandler),
                        typeof(Register)
                    ))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                )                
                .AddScoped(typeof(IRepository<User>), typeof(Repository<User>));
        }
    }
}
