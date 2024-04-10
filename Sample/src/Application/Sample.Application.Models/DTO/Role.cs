using CMS.enums;

namespace Sample.Application.Sample.Application.Models.DTO;

public class Role
{
    public UserRole RoleType { get; set; }
    public string Description { get; set; }

    public Role(UserRole roleType, string description)
    {
        RoleType = roleType;
        Description = description;
    }
}