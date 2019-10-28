using Microsoft.EntityFrameworkCore;
using MSRegistry.Model;

namespace MSRegistry.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData( new User { Id = 1, UserName = "SSoler", Password = "test1234"});
        }
    }
}
