using AutoMapper;

namespace MSCustomers.Model
{
    public class CustomerDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DNI { get;  set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public Customer ToEntity()
        {
            var customer = new Customer();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CustomerDTO, Customer>(); });
            IMapper iMapper = config.CreateMapper();

            customer = iMapper.Map<CustomerDTO, Customer>(this);

            return customer;
        }
    }
}
