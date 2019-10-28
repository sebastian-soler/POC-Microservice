using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using MSRents.Business;
using MSRents.Model;

namespace MSRents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService) => _rentalService = rentalService;

        [HttpGet]
        public IActionResult Get()
        {
            var rentals = _rentalService.GetAll();

            return new OkObjectResult(rentals);
        }

        [HttpGet("{id}", Name = "GetRental")]
        public IActionResult Get(int id)
        {
            var rental = _rentalService.Get(id);

            return new OkObjectResult(rental);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RentalDto rentalDto)
        {
            var rental = rentalDto.ToEntity();

            using (var scope = new TransactionScope())
            {
                _rentalService.Add(rental);
                scope.Complete();

                return CreatedAtAction(nameof(Get), new { id = rental.Id }, rental);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _rentalService.Remove(id);

            return new OkResult();
        }
    }
}