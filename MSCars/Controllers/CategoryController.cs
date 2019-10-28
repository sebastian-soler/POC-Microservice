using System;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using MSCars.Business.Interfaces;
using MSCars.Model;
using Newtonsoft.Json;

namespace MSCars.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAll();

            return new OkObjectResult(categories);
        }

        // GET: api/Category/1
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);

            return new OkObjectResult(category);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            using (var scope = new TransactionScope())
            {
                _categoryService.Add(category);
                scope.Complete();

                return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
            }
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Remove(id);

            return new OkResult();
        }
    }
}
