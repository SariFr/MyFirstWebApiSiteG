using AutoMapper;
using DTO;
using Entities;
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
        public async Task<ActionResult<OrderDTO>> AddOrder(OrderDTO orders)
        {
            
                Order order = _Mapper.Map<OrderDTO, Order>(orders);
                Order orderCreate = await _orderService.AddOrderAsync(order);
                OrderDTO orderDTO = _Mapper.Map<Order, OrderDTO>(orderCreate);
                return orderCreate != null ? CreatedAtAction(nameof(AddOrder), new { id = orderDTO.UserId }, orderDTO) : NoContent();
            
            
        }
     
    }
}
