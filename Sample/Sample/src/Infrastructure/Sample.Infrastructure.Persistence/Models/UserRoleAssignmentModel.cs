using CMS.enums;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

public class UserRoleAssignmentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public UserModel User { get; set; }
    public UserRole Role { get; set; }
    
 

    public UserRoleAssignmentModel(UserModel user, UserRole role, int userId, int id) 
    {
        User = user; 
        Role = role;
        UserId = userId;


        
    }

   
}