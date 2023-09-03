using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string passwod)
    {
        // Check if user already exists

        // Create user (generator unique ID)

        // Create JWT token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GeneratorToken(userId, firstName, lastName);
        return new AuthenticationResult(userId, firstName, lastName, email, token);

    }
    public AuthenticationResult Login(string email, string passwod)
    {

        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }

}