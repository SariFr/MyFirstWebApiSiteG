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
    public class productRepository : IproductRepository
    {
        private readonly WebElectricStoreContext _WebElectricStoreContext;

        public productRepository(WebElectricStoreContext WebElectricStoreContext)
        {
            _WebElectricStoreContext = WebElectricStoreContext;
        }
        public async Task<IEnumerable<Product>> getProductAsync(int? position, int? skip,string? name,int? minPrice, int? maxPrice, int?[]categoryIds )
        {
            var query = _WebElectricStoreContext.Products.Where(product =>
            (name == null ? (true) : (product.Name.Contains(name)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price >= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))
            ).OrderBy(product => product.Price);
            

            return await query.ToListAsync();
        }
    }
}
