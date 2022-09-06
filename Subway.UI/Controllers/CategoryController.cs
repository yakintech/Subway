using Microsoft.AspNetCore.Mvc;
using Subway.UI.Models;

namespace Subway.UI.Controllers
{

    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
  
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category() { Name = "Electronic", Description = "Electronic products"},
                new Category() { Name = "Sport", Description = "Sports products"}
            };
        }

        [Route("{id}")]
        public Category Index(int id)
        {
            return new Category()
            {
                Name = "Electronic",
                Description = "Lorem ipsum..."
            };
        }

        [Route("single")]
        [HttpPost]
        public IActionResult Add([FromBody] Category category)
        {

            return StatusCode(422, new Category());


            // return Ok();

            //return NotFound(new ErrorResponseDto
            //{
            //    Success = false,
            //    Errors = new List<string>()
            //    {
            //         "something is missing!"
            //    }
            //});
        }
    }
}
