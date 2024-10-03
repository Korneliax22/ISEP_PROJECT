using Microsoft.AspNetCore.Identity;

namespace ProjectIsep;

public class User
{
    public string Username { get; private set; }
    public UserRole Role { get; set;}
    public string Email { get; set;}

    public bool active { get; set;}

    public User(string username, UserRole role, string email)
        {
            Username = username;
            Role = role;
            Email = email;
        }
}
