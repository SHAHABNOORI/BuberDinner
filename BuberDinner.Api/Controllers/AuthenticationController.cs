using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult =
            _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        //return registerResult.MatchFirst(
        //    authResult => Ok(MapAuthResult(authResult)),
        //    firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description));

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            Problem);

        //Result<AuthenticationResult> registerResult =
        //    _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        //if (registerResult.IsSuccess)
        //    return Ok(MapAuthResult(registerResult.Value));

        //var firstError = registerResult.Errors.First();
        //if (firstError is DuplicateEmailError)
        //{
        //    return Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Message);
        //}

        //return Problem();

        //OneOf<AuthenticationResult, IError> registerResult =
        //    _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        //return registerResult.Match(
        //    authResult => Ok(MapAuthResult(authResult)),
        //    error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));


        //if (registerResult.IsT0)
        //{
        //    var authResult = registerResult.AsT0;
        //    var response = MapAuthResult(authResult);
        //    return Ok(response);
        //}

        //return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exist.");
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName,
            authResult.User.Email, authResult.Token);
    }

    //[HttpPost("login")]
    //public IActionResult Login(LoginRequest request)
    //{
    //    var loginResult = _authenticationService.Login(request.Email, request.Password);
    //    var response = new AuthenticationResponse(loginResult.User.Id, loginResult.User.FirstName, loginResult.User.LastName,
    //        loginResult.User.Email, loginResult.Token);
    //    return Ok(response);
    //}


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        return authResult.Match(result => Ok(MapAuthResult(result)),
            Problem);

    }
}