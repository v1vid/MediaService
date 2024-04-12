using CMS.enums;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

public class UserModel
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<Role> Roles { get; set; }

    public UserModel(int userId, string username, string password, string email)
    {
        UserId = userId;
        Username = username;
        Password = password;
        Email = email;
        Roles = new List<Role>();
    }
    public void AddRole(UserRole roleType, string description)
    {
        Roles.Add(new Role(roleType, description));
    }

    public void RemoveRole(UserRole roleType)
    {
        Roles.RemoveAll(r => r.RoleType == roleType);
    }
    public bool HasRole(UserRole roleType)
    {
        return Roles.Exists(r => r.RoleType == roleType);
    }
}