using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Data;

namespace AddisEats.Api.Services.OrderServices;

public class OrderService : IOrderService
{
    private readonly List<Order> orderList = SeedData.listOfOrders;

    public List<Order> GetAllOrders(string? OrderLocation , int page  , int pageSize )
    {
       var result = orderList.Where(o => OrderLocation == null || o.OrderLocation ==OrderLocation)
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
       return null;
    }
    
};