using System;
using Microsoft.EntityFrameworkCore;
using MSRents.Model;

namespace MSRents.DbContexts
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasData(
                new Rental { Id = 1, CarId = 1, CustomerId = 1, InitialDay = DateTime.Now, FinalDay = DateTime.Now.AddDays(20), Price = 2000 }/*,
                new Rental { Id = 2, CarId = 2, CustomerId = 2, InitialDay = DateTime.Now, FinalDay = DateTime.Now.AddDays(10), Price = 1500 }*/
                );
        }   
    }
}
