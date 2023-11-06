using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public interface IorderService
{
    Task<Order> AddOrderAsync(Order order);
}
