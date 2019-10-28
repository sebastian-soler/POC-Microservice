using System;
using System.Collections.Generic;
using System.Linq;
using MSCustomers.Model;
using MSCustomers.Repository;

namespace MSCustomers.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) => _customerRepository = customerRepository;

        public void Add(Customer customer)
        {
            if (customer == null || customer.Id != 0) throw new Exception("El cliente no puede ser nulo.");

            if (string.IsNullOrEmpty(customer.FirstName) && string.IsNullOrEmpty(customer.LastName)) throw new Exception("Valide que el nombre y/o apellido del Cliente se encuentren correctamente cargados.");

            if (_customerRepository.GetAll().Any(x => x.Email.Equals(customer.Email, StringComparison.OrdinalIgnoreCase))) throw new Exception("El email ingresado ya se encuentra registrado.");

            _customerRepository.Add(customer);
        }

        public Customer Get(int customerId)
        {
            var customer = _customerRepository.Get(customerId);

            if (customer == null) throw new Exception("El cliente que intenta obtener no se encuentra registrado.");

            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll().ToList();
        }

        public void Remove(int customerId)
        {
            _customerRepository.Remove(customerId);
        }

        public void Update(Customer customer)
        {
            if (customer.Id == 0) throw new Exception("El cliente a actualizar es invalido.");

            _customerRepository.Update(customer);
        }
    }
}
