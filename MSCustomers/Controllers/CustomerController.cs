using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using MSCustomers.Model;
using MSCustomers.Business;

namespace MSCustomers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) => _customerService = customerService;

        // GET: api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetAll();

            return new OkObjectResult(customers);
        }

        // GET: api/Customer/1
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.Get(id);

            return new OkObjectResult(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDTO customerDto)
        {
            var customer = customerDto.ToEntity();

            using (var scope = new TransactionScope())
            {
                _customerService.Add(customer);
                scope.Complete();

                return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
            }
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.Remove(id);

            return new OkResult();
        }
    }
}