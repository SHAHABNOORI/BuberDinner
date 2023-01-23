using System.Net;
using FluentResults;

namespace BuberDinner.Application.Common.Errors;

//public record struct DuplicateEmailError : IError
//{
//    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

//    public string ErrorMessage => "Email already exists";
//}



public class DuplicateEmailError : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
}