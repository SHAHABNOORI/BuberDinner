﻿//using BuberDinner.Application.Authentication.Common;
//using BuberDinner.Application.Common.Interfaces.Authentication;
//using BuberDinner.Application.Common.Interfaces.Persistence;
//using BuberDinner.Domain.Common.Erros;
//using BuberDinner.Domain.Entities;
//using ErrorOr;

//namespace BuberDinner.Application.Services.Authentication.Queries;

//public class AuthenticationQueryService : IAuthenticationQueryService
//{
//    private readonly IJwtTokenGenerator _jwtTokenGenerator;
//    private readonly IUserRepository _userRepository;

//    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
//    {
//        _jwtTokenGenerator = jwtTokenGenerator;
//        _userRepository = userRepository;
//    }

//    public ErrorOr<AuthenticationResult> Login(string email, string password)
//    {
//        // 1. Validate the user exist
//        var user = _userRepository.GetUserByEmail(email) as User;
//        if (user == null)
//            return Errors.Authentication.InvalidCredentials;

//        // 2. Validate the password is correct
//        if (user.Password != password)
//            return new[] { Errors.Authentication.InvalidCredentials };

//        // 3. Create JWT token
//        var token = _jwtTokenGenerator.GenerateToken(user);
//        return new AuthenticationResult(
//            user,
//            token);
//    }

//}