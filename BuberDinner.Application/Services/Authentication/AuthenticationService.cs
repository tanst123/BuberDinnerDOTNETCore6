using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1. Validate the user doesn't exist
        if (_userRepository.getUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        //2. Create user (generator unique ID) & Persist to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);
        //3. Create JWT token
        var token = _jwtTokenGenerator.GeneratorToken(user);
        return new AuthenticationResult(user, token);

    }
    public AuthenticationResult Login(string email, string password)
    {
        //1. Validate the user exists
        if (_userRepository.getUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }

        //2. Check the password
        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
        }

        var token = _jwtTokenGenerator.GeneratorToken(user);

        return new AuthenticationResult(user, token);
    }

}