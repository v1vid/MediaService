using CMS.enums;

namespace CMS.Repositories
{
    public class UserRoleAssignmentRepository
    {
        private readonly List<UserRoleAssignment> _userRoleAssignments;

        public UserRoleAssignmentRepository()
        {
            _userRoleAssignments = new List<UserRoleAssignment>();
        }

        public IEnumerable<UserRoleAssignment> GetAllUserRoleAssignments()
        {
            return _userRoleAssignments;
        }

        public IEnumerable<UserRoleAssignment> GetUserRoleAssignmentsForUser(User user)
        {
            return _userRoleAssignments.Where(ura => ura.User == user);
        }

        public IEnumerable<UserRoleAssignment> GetUserRoleAssignmentsForRole(UserRole role)
        {
            return _userRoleAssignments.Where(ura => ura.Role == role);
        }

        public void AddUserRoleAssignment(UserRoleAssignment userRoleAssignment)
        {
            _userRoleAssignments.Add(userRoleAssignment);
        }

        public void RemoveUserRoleAssignment(UserRoleAssignment userRoleAssignment)
        {
            _userRoleAssignments.Remove(userRoleAssignment);
        }

        public void RemoveUserRoleAssignmentsForUser(User user)
        {
            _userRoleAssignments.RemoveAll(ura => ura.User == user);
        }

        public void RemoveUserRoleAssignmentsForRole(UserRole role)
        {
            _userRoleAssignments.RemoveAll(ura => ura.Role == role);
        }
    }
}