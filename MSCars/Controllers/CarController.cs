using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using MSCars.Business.Interfaces;
using MSCars.Model;

namespace MSCars.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService) => _carService = carService;

        // GET: api/Car
        [HttpGet]
        public IActionResult Get()
        {
            var cars = _carService.GetAll();

            return new OkObjectResult(cars);
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult Get(int id)
        {
            var car = _carService.Get(id);

            return new OkObjectResult(car);
        }

        // POST: api/Car
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            using (var scope = new TransactionScope())
            {
                _carService.Add(car);
                scope.Complete();

                return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
            }
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Car car)
        {
            using (var scope = new TransactionScope())
            {
                _carService.Update(car);
                scope.Complete();

                //return new OkResult();
                return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _carService.Remove(id);

            return new OkResult();
        }
    }
}
