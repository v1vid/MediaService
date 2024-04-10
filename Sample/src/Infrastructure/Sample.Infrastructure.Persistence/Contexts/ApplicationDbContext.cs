using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Models;

namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<PageModel> Pages { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserRoleAssignmentModel> UserRoleAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}