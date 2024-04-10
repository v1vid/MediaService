using CMS.enums;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

public class RoleModel
{
    public UserRole RoleType { get; set; }
    public string Description { get; set; }

    public RoleModel(UserRole roleType, string description)
    {
        RoleType = roleType;
        Description = description;
    }
}