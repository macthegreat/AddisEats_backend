using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Data;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace AddisEats.Api.Services.OrderServices;

public class OrderService : IOrderService
{
    private static readonly List<Order> orderList = SeedData.listOfOrders;
    private static int _nextId = 1;

    public List<Order> GetAllOrders(string? OrderLocation , int page  , int pageSize )
    {
       var result = orderList.Where(o => OrderLocation == null || o.DeliveryAddress ==OrderLocation)
       .OrderBy(r => r.CustomerName)
       .Skip((page -1) *pageSize)
       .Take(pageSize)
       .ToList();

       return result;
    }

    public Order? GetOrderById(int id)
    {
        var order = orderList.FirstOrDefault(o => o.Id == id);
        return order;
    }

    public Order CreateNewOrder(CreateOrderDto createOrderDto)
    {
       Order order = new Order
       {
           Id = _nextId++,
           RestaurantId =createOrderDto.RestaurantId,
           MenuItemId=createOrderDto.menuItemId,
           CustomerName = createOrderDto.CustomerName,
           DeliveryAddress = createOrderDto.DeliveryAddress,
           Quantity =createOrderDto.Quantity,
           TotalAmount = createOrderDto.TotalAmount

       };
       orderList.Add(order);
       return order;
    }
    
};