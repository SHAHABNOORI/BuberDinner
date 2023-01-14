//using System.Net;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Mvc;

//namespace BuberDinner.Api.Controllers;

//[ApiExplorerSettings(IgnoreApi = true)]
//public class ErrorsController : ControllerBase
//{
//    [Route("/error")]
//    //public IActionResult Error() => Problem();
//    public IActionResult Error()
//    {
//        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//        return Problem(title: exception?.Message, statusCode: (int?)HttpStatusCode.Conflict);
//    }
//}