using CMS.enums;
namespace CMS.Repositories
{
    public class RoleRepository
    {
        private readonly List<Role> _roles;

        public RoleRepository()
        {
            _roles = new List<Role>();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roles;
        }

        public Role GetRoleByType(UserRole roleType)
        {
            return _roles.FirstOrDefault(r => r.RoleType == roleType);
        }

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }

        public void UpdateRole(Role role)
        {
            var existingRole = _roles.FirstOrDefault(r => r.RoleType == role.RoleType);
            if (existingRole != null)
            {
                existingRole.Description = role.Description;
            }
        }

        public void DeleteRole(UserRole roleType)
        {
            var roleToRemove = _roles.FirstOrDefault(r => r.RoleType == roleType);
            if (roleToRemove != null)
            {
                _roles.Remove(roleToRemove);
            }
        }
    }
}