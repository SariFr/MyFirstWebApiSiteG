using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;


public class categoryService : IcategoryService
{
    private readonly IcategoryRepository _catgoryRepository;

    public categoryService(IcategoryRepository catgoryRepository)
    {
        _catgoryRepository = catgoryRepository;
    }

    public async Task<IEnumerable<Category>> getCategoriesAsync()
    {
        return await _catgoryRepository.getCategoriesAsync();
    }



}