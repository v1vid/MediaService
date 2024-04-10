using CMS.enums;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : RepositoryBase<Role, Role>
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        protected override DbSet<Role> DbSet => _context.Set<Role>();

        protected override Role MapFrom(Role entity)
        {
            return new Role(entity.RoleType, entity.Description)
            {
                RoleType = entity.RoleType,
                Description = entity.Description
            };
        }

        protected override bool Equal(Role entity, Role model)
        {
            return entity.RoleType == model.RoleType;
        }

        protected override void UpdateModel(Role model, Role entity)
        {
            model.Description = entity.Description;
        }


        public IEnumerable<Role> GetAllRoles()
        {
            return DbSet.ToList();
        }

        public Role GetRoleByType(UserRole roleType)
        {
            return DbSet.FirstOrDefault(r => r.RoleType == roleType);
        }

        public void AddRole(Role role)
        {
            DbSet.Add(role);
        }

        public void DeleteRole(UserRole roleType)
        {
            var roleToRemove = DbSet.FirstOrDefault(r => r.RoleType == roleType);
            if (roleToRemove != null)
            {
                DbSet.Remove(roleToRemove);
            }
            else
            {
                throw new ArgumentException("Роль не найдена");
            }
        }
    }
}