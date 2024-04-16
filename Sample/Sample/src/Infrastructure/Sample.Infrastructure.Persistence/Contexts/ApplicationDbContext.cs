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

        public DbSet<ArticleModel> Articles { get; protected init; }
        public DbSet<PageModel> Pages { get; protected init; }
        public DbSet<RoleModel> Roles { get; protected init; }
        public DbSet<TagModel> Tags { get; protected init; }
        public DbSet<UserModel> Users { get; protected init; }
        public DbSet<UserRoleAssignmentModel> UserRoleAssignments { get; protected init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}