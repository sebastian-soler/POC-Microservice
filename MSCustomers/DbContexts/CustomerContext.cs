using Microsoft.EntityFrameworkCore;
using MSCustomers.Model;

namespace MSCustomers.DbContexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Sebastian", LastName = "Soler", Email = "sebastian.soler@globallogic.com", DNI = 36443567, Phone = "2257664064"},
                new Customer { Id = 2, FirstName = "Cosme", LastName = "Fulanito", Email = "cosme.fulanito@globallogic.com", DNI = 32432765, Phone = "22378123412" }
                );
        }
    }
}
