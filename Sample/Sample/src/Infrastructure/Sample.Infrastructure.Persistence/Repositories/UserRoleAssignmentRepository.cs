using CMS.enums;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class UserRoleAssignmentRepository : RepositoryBase<UserRoleAssignment, UserRoleAssignmentModel>
    {
        private readonly DbContext _context;

        public UserRoleAssignmentRepository(DbContext context) : base(context)
        {
            _context = context;

        }

        protected override DbSet<UserRoleAssignmentModel> DbSet => _context.Set<UserRoleAssignmentModel>();

        protected override UserRoleAssignmentModel MapFrom(UserRoleAssignment entity)
        {
            var userModel = new UserModel(entity.User.UserId, entity.User.Username, entity.User.Password, entity.User.Email);
            
            return new UserRoleAssignmentModel(userModel, entity.Role, entity.UserId, entity.Id)
            {
                UserId = entity.UserId,
                Role = entity.Role,
                User = userModel

            };
        }

        protected override bool Equal(UserRoleAssignment entity, UserRoleAssignmentModel model)
        {
            return entity.UserId == model.UserId && entity.Role == model.Role;
        }

        protected override void UpdateModel(UserRoleAssignmentModel model, UserRoleAssignment entity)
        {
            model.UserId = entity.UserId;
            model.Role = entity.Role;           
        }


        public IEnumerable<UserRoleAssignmentModel> GetAllUserRoleAssignments()
        {
            return DbSet.ToList();
        }

        public IEnumerable<UserRoleAssignmentModel> GetUserRoleAssignmentsForUser(UserModel user)
        {
            return DbSet.Where(ura => ura.User == user).ToList();
        }

        public IEnumerable<UserRoleAssignmentModel> GetUserRoleAssignmentsForRole(UserRole role)
        {
            return DbSet.Where(ura => ura.Role == role).ToList();
        }

        public void AddUserRoleAssignment(UserRoleAssignmentModel userRoleAssignment)
        {
            DbSet.Add(userRoleAssignment);
        }

        

        public void RemoveUserRoleAssignment(UserRoleAssignmentModel userRoleAssignment)
        {
            DbSet.Remove(userRoleAssignment);
        }

        public void RemoveUserRoleAssignmentsForUser(UserModel user)
        {
            DbSet.RemoveRange(DbSet.Where(ura => ura.User == user));
        }

        public void RemoveUserRoleAssignmentsForRole(UserRole role)
        {
            DbSet.RemoveRange(DbSet.Where(ura => ura.Role == role));
        }
    }
}
