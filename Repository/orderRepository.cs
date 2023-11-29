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
    public class orderRepository:IorderRepository
    
    {
        private readonly WebElectricStoreContext _webElectricStoreContext;
        public orderRepository(WebElectricStoreContext WebElectricStore1Context)
        {
            _webElectricStoreContext = WebElectricStore1Context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _webElectricStoreContext.Orders.AddAsync(order);
            await _webElectricStoreContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Product>> GetProductsById(int[] prodsId)
        {
            //IEnumerable<Product> listProduct = new IEnumerable<Product>();
            
            var query= _webElectricStoreContext.Products.Where(p => prodsId.Contains(p.ProductId));
            return await query.ToListAsync();


        }
    }
}
