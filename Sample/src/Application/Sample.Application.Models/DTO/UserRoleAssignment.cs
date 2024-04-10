using CMS.enums;

namespace Sample.Application.Sample.Application.Models.DTO;

public class UserRoleAssignment
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    public UserRole Role { get; set; }

    public UserRoleAssignment(User user, UserRole role, int userId, int id) 
    {
        User = user; 
        Role = role;
        UserId = userId;


        
    }
}