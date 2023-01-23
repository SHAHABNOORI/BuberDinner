using ErrorOr;

namespace BuberDinner.Domain.Common.Erros;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation("Auth.InvalidCred", "Invalid Credentials");
    }

}