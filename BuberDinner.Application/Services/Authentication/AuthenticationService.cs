using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exist
        var user = _userRepository.GetUserByEmail(email) as User;
        if (user == null)
            throw new Exception("Email or password is not correct");

        // 2. Validate the password is correct
        if (user.Password != password)
            throw new Exception("Email or password is not correct");

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
            throw new Exception("User with given email is already exist");


        // Create user (generate unique Id) & Persist
        var user = new User()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password
        };
        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }
}