using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class productRepository:IproductRepository
{
    private readonly WebElectricStoreContext _WebElectricStoreContext;
    public productRepository(WebElectricStoreContext WebElectricStoreContext)
    {
        _WebElectricStoreContext = WebElectricStoreContext;
    }
    public async Task<IEnumerable<Product>> getProductsAsync()
    {
        return await _WebElectricStoreContext.Products.ToListAsync();
    }
}
