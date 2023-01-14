using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails()
        {
            Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
            Instance = context.HttpContext.Request.Path,
            Status = (int?)HttpStatusCode.InternalServerError,
            Detail = exception.Message
        };

        context.Result = new ObjectResult(problemDetails);

        //context.Result = new ObjectResult(
        //    new
        //    {
        //        error = "An error occurred while processing your request."
        //    })
        //{
        //    StatusCode = (int?)HttpStatusCode.InternalServerError
        //};

        context.ExceptionHandled = true;
    }
}