using Microsoft.EntityFrameworkCore;
using MSCars.Model;

namespace MSCars.DBContexts
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Enrollment = "NOD 123", Mark = "Subaru", Model = "BRZ", CategoryId = 1 },
                new Car { Id = 2, Enrollment = "PHP 567", Mark = "Toyota", Model = "Yaris", CategoryId = 2 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sport", Description = "Sports Vehicles" },
                new Category { Id = 2, Name = "Sedan", Description = "Sedan Vehicles" },
                new Category { Id = 3, Name = "SUV", Description = "SUV Vehicles" },
                new Category { Id = 4, Name = "Van", Description = "Van Vehicles" }
            );
        }
    }
}
