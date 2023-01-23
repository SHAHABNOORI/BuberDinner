using ErrorOr;

namespace BuberDinner.Domain.Common.Erros;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict("User.DuplicateEmail", "Email already exists");
    }

}