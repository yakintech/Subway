using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subway.UI.Models;
using Subway.UI.Models.dto;

namespace Subway.UI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            SubwayContext subwayContext = new SubwayContext();

            var products = subwayContext.Products
                .Include(s => s.Supplier).ToList();

            return Ok(products);
        }



        [HttpPost]
        public IActionResult Add(ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(model);
            }
            else
            {
                return Ok("OK!");

            }
        }
    }
}
