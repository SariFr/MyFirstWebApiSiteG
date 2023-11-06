using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class orderRepository : IorderRepository
{
    private readonly WebElectricStoreContext _WebElectricStoreContext;


    public orderRepository(WebElectricStoreContext WebElectricStoreContext)
    {
        _WebElectricStoreContext = WebElectricStoreContext;
    }
    public async Task<Order> AddOrderAsync(Order order)
    {
        await _WebElectricStoreContext.Orders.AddAsync(order);
        await _WebElectricStoreContext.SaveChangesAsync();

        return order;
    }
}
