using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductDemoApp.Data;
using ProductDemoApp.Models;
using System.Diagnostics.Eventing.Reader;

namespace ProductDemoApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;


        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            // logger has been added
        }


        [HttpGet]

        public IActionResult GetAll()
        {
            var products = AppDbContext.Products;

            return Ok(products);
        }
        [HttpGet("{id:int}")]

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {

            var product = AppDbContext.Products
                .Where(p => p.Id == id)
                .SingleOrDefault();

            return Ok(product);

        }
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {

            try
            {
                if (product is null)
                    return BadRequest();

                AppDbContext.Products.Add(product);
                _logger.LogInformation(product.Title + " Eklendi");
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                _logger.LogInformation("ürün eklenemedi ");
                return BadRequest(ex.Message);
            }
        }


       [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute(Name ="id")] int id , [FromBody] Product product)
        {
            var entity = AppDbContext.Products.Find(p => p.Id.Equals(id));

            if (entity is null)
            {
                _logger.LogWarning("ürün bulunamadı");
                return NotFound(); // return 404
            }

            if (id != product.Id)
                return BadRequest("kötü niyetli herif ");  // return 400


            AppDbContext.Products.Remove(entity);

            product.Id = entity.Id;
            AppDbContext.Products.Add(product);
            return StatusCode(200); // retun hass been created :D  200



        }
        [HttpPatch("{id:int}")]
        public IActionResult UpdateImg([FromRoute(Name ="id")]int id,
            [FromBody] JsonPatchDocument<Product> productPatch)
        {
            //check entity
            var entity = AppDbContext.Products.Find(p => p.Id.Equals(id));
            if (entity is null)
                return NotFound();

            productPatch.ApplyTo(entity);
            return NoContent(); // return 204

        }
    }
}
