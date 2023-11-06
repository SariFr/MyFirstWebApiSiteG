using Entity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class productService : IproductService
{ 
    private readonly IproductRepository _productRepository;
    public productService(IproductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> getProductsAsync()
    {
        return await _productRepository.getProductsAsync();
    }
}
