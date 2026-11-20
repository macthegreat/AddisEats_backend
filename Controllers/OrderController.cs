using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Models;
using AddisEats.Api.Services.OrderServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AddisEats.Api.Mappers;
using AddisEats.Api.DTOs;
using AddisEats.Api.Common;

namespace AddisEats.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet()]
        public IActionResult GetAllOrders([FromQuery] string? OrderLocation, int Page = 1, int pageSize = 5)
        {
            var orders = _orderService.GetAllOrders(OrderLocation, Page, pageSize);
            var orderDto = orders.Select(o => o.ToOrderDto()).ToList();
            return Ok(orderDto);
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.ToOrderDto());
        }

        [HttpPost()]
        public IActionResult CreateNewOrder([FromBody] CreateOrderDto createOrderDto)
        {

            var newOrder = _orderService.CreateNewOrder(createOrderDto);
            if (!newOrder.IsSuccess)
            {
                return Problem(
                    title: newOrder?.error.Message,
                    statusCode: newOrder?.error.Status,
                    detail: newOrder?.error.Code

                );
            }
            var order = newOrder.Value;
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, newOrder);

        }
    }
}