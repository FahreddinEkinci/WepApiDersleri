using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> loger)
        {
            _logger = loger;
        }

        [HttpGet]


            
        public IActionResult Get() { 
        
            List<Product> products = new (){
            
            new Product{ Id = 1, Name="Computer"},
            new Product{ Id = 2, Name="Calculator"},
            new Product{ Id = 2, Name="Printer"},
            new Product{ Id = 1, Name="Siccors"}

            };

            _logger.LogInformation("products has been called from restfullapi");
            _logger.LogDebug("get all products action has been called from restfull api");
            return Ok(products);
        }

    }
}
