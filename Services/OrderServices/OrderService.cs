using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Data;
using AddisEats.Api.Common;
using AddisEats.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace AddisEats.Api.Services.OrderServices;

public class OrderService : IOrderService
{

        //DI injected restaurant
    private readonly IRestaurantService _restaurantService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IRestaurantService restaurantService, ILogger<OrderService> logger)
    {
        _restaurantService = restaurantService;
        _logger=logger;
    }

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

    public Result<Order> CreateNewOrder(CreateOrderDto createOrderDto)
    {

    var restaurnat = _restaurantService.GetRestaurantById(createOrderDto.RestaurantId);
    if(restaurnat == null)
        {
            return Result<Order>.fail("Restaurant Not Found","The restaurant you tring to access is not here",404);
        }
        if (!restaurnat.IsActive)
        {
            return Result<Order>.fail("restaurant Is Not Active", "the selected restaurant is not active yet", 409);
        }

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
       return Result<Order>.Ok(order);
    }
    
};