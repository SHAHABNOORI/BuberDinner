//using BuberDinner.Application.Authentication.Common;
//using ErrorOr;

//namespace BuberDinner.Application.Services.Authentication.Commands;

//public interface IAuthenticationCommandService
//{
//    #region Commented

//    //AuthenticationResult Login(string email, string password);

//    //OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);

//    //Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

//    #endregion

//    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
//}