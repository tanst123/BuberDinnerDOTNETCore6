namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string passwod);
    AuthenticationResult Login(string email, string passwod);
}