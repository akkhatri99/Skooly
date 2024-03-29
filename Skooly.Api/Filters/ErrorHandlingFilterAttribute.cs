﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Skooly.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = "An Error occured while processing your request",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
            };
            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
