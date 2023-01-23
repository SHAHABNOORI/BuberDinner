﻿using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    //AuthenticationResult Login(string email, string password);

    ErrorOr<AuthenticationResult> Login(string email, string password);

    //OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);

    //Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);


    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}