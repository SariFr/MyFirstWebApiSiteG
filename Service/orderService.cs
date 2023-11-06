﻿using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public class orderService : IorderService
{
    private readonly IorderRepository _orderRepository;
    public orderService(IorderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<Order> AddOrderAsync(Order order)
    {
        return await _orderRepository.AddOrderAsync(order);
    }
}