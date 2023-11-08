using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSiteG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {

        IproductService _productService;

        public productController(IproductService productService)
        {
            _productService = productService;
        }
        // GET: api/<productController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productService.getProductsAsync();
        }
        

        // GET api/<productController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<productController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<productController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<productController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
