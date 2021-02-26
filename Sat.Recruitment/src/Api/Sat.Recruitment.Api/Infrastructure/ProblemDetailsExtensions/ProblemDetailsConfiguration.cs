using Hellang.Middleware.ProblemDetails;
using Sat.Recruitment.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Sat.Recruitment.Api.Infrastructure.ProblemDetailsExtensions
{
    public static class ProblemDetailsConfiguration
    {
        public static void ProblemDetailsMapConfiguration(this ProblemDetailsOptions config)
        {
            config.Map<EntityCollectionEmptyException>((context, ex) =>
                new ProblemDetails
                {
                    Title = ApiConstants.EntitiesNotFound,
                    Status = StatusCodes.Status404NotFound,
                    Detail = ex.Message
                });

            config.Map<EntityNotFoundException>((context, ex) =>
                new ProblemDetails
                {
                    Title = ApiConstants.EntityNotFound,
                    Status = StatusCodes.Status404NotFound,
                    Detail = ex.Message
                });

            config.Map<EntityAlreadyExistsException>((context, ex) =>
                new ProblemDetails
                {
                    Title = ApiConstants.EntityConflict,
                    Status = StatusCodes.Status409Conflict,
                    Detail = ex.Message
                });

            config.Map<EntityForbiddenException>((context, ex) =>
                new ProblemDetails
                {
                    Title = ApiConstants.EntityForbidden,
                    Status = StatusCodes.Status403Forbidden,
                    Detail = ex.Message
                });          

            config.Map<Exception>((context, ex) =>
                new ProblemDetails
                {
                    Title = ApiConstants.ServerErrorReturn,
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = ex.InnerException == null ? ex.Message : ex.InnerException + ". " + ex.Message
                });
        }
    }
}
