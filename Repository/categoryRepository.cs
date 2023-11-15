using Entity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class categoryRepository:IcategoryRepository
    {
        private readonly WebElectricStoreContext _WebElectricStoreContext;


        public categoryRepository(WebElectricStoreContext WebElectricStoreContext)
        {
            _WebElectricStoreContext = WebElectricStoreContext;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _WebElectricStoreContext.Categories.ToListAsync();
        }
    }
}
