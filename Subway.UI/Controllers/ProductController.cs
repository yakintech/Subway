using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subway.UI.Models;
using Subway.UI.Models.dto;
using Subway.UI.Models.filters;

namespace Subway.UI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            SubwayContext subwayContext = new SubwayContext();

            //var products = subwayContext.Products
            //    .Include(s => s.Supplier).ToList();



            var products = new List<Product>()
            {
                new Product(){Name = "IPhone", UnitPrice = 33, Id = 1},
                new Product(){Name = "IPhone2", UnitPrice = 11, Id = 2},
                new Product(){Name = "IPhone3", UnitPrice = 22, Id = 3},

            };

            var model = _mapper.Map<List<ProductDto>>(products);

            

            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        [ExceptionFilter]
        public IActionResult Index(int id)
        {
            throw new DataNotFoundException(nameof(Product), id);
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
