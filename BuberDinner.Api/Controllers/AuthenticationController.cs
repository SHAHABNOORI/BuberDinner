using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    #region Commented

    //[HttpPost("login")]
    //public IActionResult Login(LoginRequest request)
    //{
    //    var loginResult = _authenticationService.Login(request.Email, request.Password);
    //    var response = new AuthenticationResponse(loginResult.User.Id, loginResult.User.FirstName, loginResult.User.LastName,
    //        loginResult.User.Email, loginResult.Token);
    //    return Ok(response);
    //}

    #endregion


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

        #region Commented

        //ErrorOr <AuthenticationResult> registerResult =
        //    _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        //return registerResult.MatchFirst(
        //    authResult => Ok(MapAuthResult(authResult)),
        //    firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description));

        #endregion

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            Problem);

        #region Commented

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

        #endregion
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName,
            authResult.User.Email, authResult.Token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);
        return authResult.Match(result => Ok(MapAuthResult(result)),
            Problem);
    }
}