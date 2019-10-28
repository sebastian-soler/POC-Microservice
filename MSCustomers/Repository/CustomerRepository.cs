using System;
using System.Collections.Generic;
using System.Linq;
using MSCustomers.DbContexts;
using MSCustomers.Model;

namespace MSCustomers.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _dbContext;

        public CustomerRepository(CustomerContext dbContext) => this._dbContext = dbContext;

        public void Add(Customer customer)
        {
            _dbContext.Add(customer);
            Save();
        }

        public Customer Get(int customerId)
        {
            return _dbContext.Customers.SingleOrDefault(c => c.Id == customerId && !c.IsDeleted);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers.Where(c => !c.IsDeleted).ToList();
        }

        public Customer GetCustomerByDni(int dni)
        {
            return _dbContext.Customers.SingleOrDefault(c => c.DNI == dni && !c.IsDeleted);
        }

        public void Remove(int customerId)
        {
            var customer = _dbContext.Customers.Find(customerId);

            if (customer != null)
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    _dbContext.Entry(customer).Entity.IsDeleted = true;
                    Save();

                    scope.Complete();
                }
            }
        }

        public void Update(Customer customer)
        {
            var customerExists = _dbContext.Customers.Find(customer.Id);

            if (customerExists != null)
            {
                _dbContext.Entry(customerExists).CurrentValues.SetValues(customer);

                Save();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
