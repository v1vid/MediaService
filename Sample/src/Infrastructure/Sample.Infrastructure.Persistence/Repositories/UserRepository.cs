using Microsoft.EntityFrameworkCore;
using Sample.Application.Sample.Application.Models.DTO;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User, UserModel>
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;

        }

        protected override DbSet<UserModel> DbSet => _context.Set<UserModel>();

        protected override UserModel MapFrom(User entity)
        {
            return new UserModel(entity.UserId, entity.Username, entity.Password, entity.Email)
            {
                UserId = entity.UserId,
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email,
                Roles = entity.Roles
            };
        }

        protected override bool Equal(User entity, UserModel model)
        {
            return entity.UserId == model.UserId;
        }

        protected override void UpdateModel(UserModel model, User entity)
        {
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.Email = entity.Email;
            model.Roles = entity.Roles;
        }


        public IEnumerable<UserModel> GetAllUsers()
        {
            return DbSet.ToList();
        }

        public User GetUserById(int userId)
        {
        {
            var userModel = DbSet.FirstOrDefault(u => u.UserId == userId);
            if (userModel != null)
            {
                return new User(userModel.UserId, userModel.Username, userModel.Password, userModel.Email);
            }
            else
            {
                throw new ArgumentException("Пользователь не найден");
            }
        }        }

        public void AddUser(User user)
        {
            DbSet.Add(MapFrom(user));
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