using CMS.enums;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

public class UserRoleAssignmentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    public UserRole Role { get; set; }

    public UserRoleAssignmentModel(User user, UserRole role, int userId, int id) 
    {
        User = user; 
        Role = role;
        UserId = userId;


        
    }
}