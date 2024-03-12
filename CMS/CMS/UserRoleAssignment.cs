using CMS.enums;

namespace CMS;

public class UserRoleAssignment
{
    
    public int Id { get; set; }
    public User User { get; set; }
    public UserRole Role { get; set; }

    public UserRoleAssignment(User user, UserRole role) 
    {
            User = user; 
            Role = role;
    }
}