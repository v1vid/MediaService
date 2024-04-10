using CMS.enums;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class UserRoleAssignmentRepository : RepositoryBase<UserRoleAssignment, UserRoleAssignment>
    {
        public UserRoleAssignmentRepository(DbContext context) : base(context) { }

        protected override DbSet<UserRoleAssignment> DbSet => _context.Set<UserRoleAssignment>();

        protected override UserRoleAssignment MapFrom(UserRoleAssignment entity)
        {
            return new UserRoleAssignment(entity.User, entity.Role, entity.UserId, entity.Id)
            {
                UserId = entity.UserId,
                Role = entity.Role
            };
        }

        protected override bool Equal(UserRoleAssignment entity, UserRoleAssignment model)
        {
            return entity.UserId == model.UserId && entity.Role == model.Role;
        }

        protected override void UpdateModel(UserRoleAssignment model, UserRoleAssignment entity)
        {
            model.UserId = entity.UserId;
            model.User = entity.User;
            model.Role = entity.Role;
        }


        public IEnumerable<UserRoleAssignment> GetAllUserRoleAssignments()
        {
            return DbSet.ToList();
        }

        public IEnumerable<UserRoleAssignment> GetUserRoleAssignmentsForUser(User user)
        {
            return DbSet.Where(ura => ura.User == user).ToList();
        }

        public IEnumerable<UserRoleAssignment> GetUserRoleAssignmentsForRole(UserRole role)
        {
            return DbSet.Where(ura => ura.Role == role).ToList();
        }

        public void AddUserRoleAssignment(UserRoleAssignment userRoleAssignment)
        {
            DbSet.Add(userRoleAssignment);
        }

        public void RemoveUserRoleAssignment(UserRoleAssignment userRoleAssignment)
        {
            DbSet.Remove(userRoleAssignment);
        }

        public void RemoveUserRoleAssignmentsForUser(User user)
        {
            DbSet.RemoveRange(DbSet.Where(ura => ura.User == user));
        }

        public void RemoveUserRoleAssignmentsForRole(UserRole role)
        {
            DbSet.RemoveRange(DbSet.Where(ura => ura.Role == role));
        }
    }
}
