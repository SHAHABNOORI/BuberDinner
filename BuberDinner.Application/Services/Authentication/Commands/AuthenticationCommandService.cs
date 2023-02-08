//using BuberDinner.Application.Authentication.Common;
//using BuberDinner.Application.Common.Interfaces.Authentication;
//using BuberDinner.Application.Common.Interfaces.Persistence;
//using BuberDinner.Domain.Common.Erros;
//using BuberDinner.Domain.Entities;
//using ErrorOr;

//namespace BuberDinner.Application.Services.Authentication.Commands;

//public class AuthenticationCommandService : IAuthenticationCommandService
//{
//    private readonly IJwtTokenGenerator _jwtTokenGenerator;
//    private readonly IUserRepository _userRepository;

//    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
//    {
//        _jwtTokenGenerator = jwtTokenGenerator;
//        _userRepository = userRepository;
//    }

//    #region Commented

//    //public AuthenticationResult Login(string email, string password)
//    //{
//    //    // 1. Validate the user exist
//    //    var user = _userRepository.GetUserByEmail(email) as User;
//    //    if (user == null)
//    //        throw new Exception("Email or password is not correct");

//    //    // 2. Validate the password is correct
//    //    if (user.Password != password)
//    //        throw new Exception("Email or password is not correct");

//    //    // 3. Create JWT token
//    //    var token = _jwtTokenGenerator.GenerateToken(user);
//    //    return new AuthenticationResult(
//    //        user,
//    //        token);
//    //}
//    //public OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password)
//    //{
//    //    // 1. Validate the user doesn't exist
//    //    if (_userRepository.GetUserByEmail(email) is not null)
//    //        return new DuplicateEmailError();


//    //    // Create user (generate unique Id) & Persist
//    //    var user = new User()
//    //    {
//    //        Email = email,
//    //        FirstName = firstName,
//    //        LastName = lastName,
//    //        Password = password
//    //    };
//    //    _userRepository.Add(user);

//    //    // Create JWT token
//    //    var token = _jwtTokenGenerator.GenerateToken(user);


//    //    return new AuthenticationResult(user, token);
//    //}

//    //public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
//    //{
//    //    // 1. Validate the user doesn't exist
//    //    if (_userRepository.GetUserByEmail(email) is not null)
//    //        return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });


//    //    // Create user (generate unique Id) & Persist
//    //    var user = new User()
//    //    {
//    //        Email = email,
//    //        FirstName = firstName,
//    //        LastName = lastName,
//    //        Password = password
//    //    };
//    //    _userRepository.Add(user);

//    //    // Create JWT token
//    //    var token = _jwtTokenGenerator.GenerateToken(user);


//    //    return new AuthenticationResult(user, token);
//    //}


//    //public OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password)
//    //{
//    //    // 1. Validate the user doesn't exist
//    //    if (_userRepository.GetUserByEmail(email) is not null)
//    //        return new DuplicateEmailError();


//    //    // Create user (generate unique Id) & Persist
//    //    var user = new User()
//    //    {
//    //        Email = email,
//    //        FirstName = firstName,
//    //        LastName = lastName,
//    //        Password = password
//    //    };
//    //    _userRepository.Add(user);

//    //    // Create JWT token
//    //    var token = _jwtTokenGenerator.GenerateToken(user);


//    //    return new AuthenticationResult(user, token);
//    //}

//    //public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
//    //{
//    //    // 1. Validate the user doesn't exist
//    //    if (_userRepository.GetUserByEmail(email) is not null)
//    //        return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });


//    //    // Create user (generate unique Id) & Persist
//    //    var user = new User()
//    //    {
//    //        Email = email,
//    //        FirstName = firstName,
//    //        LastName = lastName,
//    //        Password = password
//    //    };
//    //    _userRepository.Add(user);

//    //    // Create JWT token
//    //    var token = _jwtTokenGenerator.GenerateToken(user);


//    //    return new AuthenticationResult(user, token);
//    //}

//    #endregion

//    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
//    {
//        // 1. Validate the user doesn't exist
//        if (_userRepository.GetUserByEmail(email) is not null)
//            return Errors.User.DuplicateEmail;


//        // Create user (generate unique Id) & Persist
//        var user = new User()
//        {
//            Email = email,
//            FirstName = firstName,
//            LastName = lastName,
//            Password = password
//        };
//        _userRepository.Add(user);

//        // Create JWT token
//        var token = _jwtTokenGenerator.GenerateToken(user);


//        return new AuthenticationResult(user, token);
//    }

//}