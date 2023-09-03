using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    public static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? getUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }

}