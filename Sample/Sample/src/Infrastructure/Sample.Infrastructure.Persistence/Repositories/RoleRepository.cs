using CMS.enums;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : RepositoryBase<Role, RoleModel>
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext context) : base(context)
        {
            _context = context;

        }

        protected override DbSet<RoleModel> DbSet => _context.Set<RoleModel>();

        protected override RoleModel MapFrom(Role entity)
        {
            return new RoleModel(entity.RoleType, entity.Description)
            {
                RoleType = entity.RoleType,
                Description = entity.Description
            };
        }

        protected override bool Equal(Role entity, RoleModel model)
        {
            return entity.RoleType == model.RoleType;
        }

        protected override void UpdateModel(RoleModel model, Role entity)
        {
            model.Description = entity.Description;
        }


        public IEnumerable<RoleModel> GetAllRoles()
        {
            return DbSet.ToList();
        }

        public Role GetRoleByType(UserRole roleType)
        {
            
                var roleModel = DbSet.FirstOrDefault(r => r.RoleType == roleType);
                if (roleModel != null)
                {
                    return new Role(roleModel.RoleType, roleModel.Description);
                }
                else
                {
                    throw new ArgumentException("Роль не найдена");
                }
        }

        public void AddRole(Role role)
        {
            DbSet.Add(MapFrom(role));
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