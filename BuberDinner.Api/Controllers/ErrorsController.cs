using System.Net;
using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    //public IActionResult Error() => Problem();
    //public IActionResult Error()
    //{
    //    var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //    return Problem(title: exception?.Message, statusCode: (int?)HttpStatusCode.Conflict);
    //}


    //public IActionResult Error()
    //{
    //    var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //    var (statusCode, message) = exception switch
    //    {
    //        DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists"),
    //        _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
    //    };
    //    return Problem(title: message, statusCode: statusCode);
    //}

    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
        };
        return Problem(title: message, statusCode: statusCode);
    }
}  