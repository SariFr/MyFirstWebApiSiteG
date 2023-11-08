using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSiteG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {
        private readonly IcategoryService _categoryService;

        public categoryController(IcategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<productController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetProductsAsync()
        {
            return await _categoryService.getCategoriesAsync();
        }


        // GET api/<categoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<categoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<categoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<categoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
