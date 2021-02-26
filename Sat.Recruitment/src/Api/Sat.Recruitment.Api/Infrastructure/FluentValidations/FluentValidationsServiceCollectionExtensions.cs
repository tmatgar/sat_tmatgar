using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Business.Users;

namespace Sat.Recruitment.Api.Infrastructure.FluentValidations
{
    public static class FluentValidationsServiceCollectionExtensions
    {
        public static IMvcBuilder AddCustomFluentValidations(this IMvcBuilder builder) =>
            builder.AddFluentValidation(
                fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
                });
    }
}
