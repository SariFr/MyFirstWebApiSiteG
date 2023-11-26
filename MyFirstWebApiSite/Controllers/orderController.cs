﻿using AutoMapper;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly IMapper _Mapper;

        IorderService _orderService;

        public orderController(IorderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _Mapper = mapper;

        }

        // POST api/<orderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder(Order order)
        {
            try
            {
                Order orderCreate = await _orderService.AddOrderAsync(order);
                OrderDTO orderDTO = _Mapper.Map<Order, OrderDTO>(orderCreate);
                return orderCreate != null ? CreatedAtAction(nameof(Get), new { id = orderDTO.UserId }, orderDTO) : NoContent();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
            }
        [HttpGet]
        public string Get(int id)
        {
            return "string";
        }
    }
}
