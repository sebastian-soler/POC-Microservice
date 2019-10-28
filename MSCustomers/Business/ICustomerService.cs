using System.Collections.Generic;
using MSCustomers.Model;

namespace MSCustomers.Business
{
    public interface ICustomerService
    {
        void Add(Customer customer);

        void Remove(int customerId);

        void Update(Customer customer);

        IEnumerable<Customer> GetAll();

        Customer Get(int customerId);
    }
}
