using AutoMapper;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IcategoryService _categoryService;

        public categoryController(IcategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _Mapper = mapper;
        }
        // GET: api/<categoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            IEnumerable<Category> category = await _categoryService.GetCategoriesAsync();
            IEnumerable<CategoryDTO> categoryDTO = _Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>> (category);
            return categoryDTO;
        }

       
    }
}
