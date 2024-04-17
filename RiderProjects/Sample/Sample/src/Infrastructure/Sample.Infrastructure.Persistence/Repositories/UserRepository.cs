using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User, User>
    {
        public UserRepository(DbContext context) : base(context) { }

        protected override DbSet<User> DbSet => _context.Set<User>();

        protected override User MapFrom(User entity)
        {
            return new User(entity.UserId, entity.Username, entity.Password, entity.Email)
            {
                UserId = entity.UserId,
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email,
                Roles = entity.Roles
            };
        }

        protected override bool Equal(User entity, User model)
        {
            return entity.UserId == model.UserId;
        }

        protected override void UpdateModel(User model, User entity)
        {
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.Email = entity.Email;
            model.Roles = entity.Roles;
        }


        public IEnumerable<User> GetAllUsers()
        {
            return DbSet.ToList();
        }

        public User GetUserById(int userId)
        {
            return DbSet.FirstOrDefault(u => u.UserId == userId);
        }

        public void AddUser(User user)
        {
            DbSet.Add(user);
        }

        public void DeleteUser(int userId)
        {
            var userToRemove = DbSet.FirstOrDefault(u => u.UserId == userId);
            if (userToRemove != null)
            {
                DbSet.Remove(userToRemove);
            }
            else
            {
                throw new ArgumentException("Пользователь не найден");
            }
        }
    }
}