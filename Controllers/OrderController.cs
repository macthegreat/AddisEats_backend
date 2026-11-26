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
using Microsoft.AspNetCore.Authorization;
using AddisEats.Api.Authorization;

namespace AddisEats.Api.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IAuthorizationService _authorizationService;

        public OrderController(IOrderService orderService, IAuthorizationService authorizationService )
        {
            _orderService = orderService;
             _authorizationService = authorizationService;
        }

        [HttpGet()]
        public IActionResult GetAllOrders([FromQuery] string? OrderLocation, int Page = 1, int pageSize = 5)
        {
            var orders = _orderService.GetAllOrders(OrderLocation, Page, pageSize);
            var orderDto = orders.Select(o => o.ToOrderDto()).ToList();
            return Ok(orderDto);
        }

        //[Authorize]
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
    // longest way to implement resource base authorization
            var result = await _authorizationService.AuthorizeAsync(User , order,OrderOperations.Read);
        if (!result.Succeeded)
        {
            return Forbid();
        }

        //shotest way of resource based authorization

        // if(order.CustomerId != int.Parse(User.FindFirst("sub")?.Value))
        // {
        //     return Forbid();
        // }

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
