using System.Collections.Generic;
using MSCustomers.Model;

namespace MSCustomers.Repository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);

        void Remove(int customerId);

        void Update(Customer customer);

        IEnumerable<Customer> GetAll();

        Customer Get(int entityId);

        Customer GetCustomerByDni(int dni);

        void Save();
    }
}
