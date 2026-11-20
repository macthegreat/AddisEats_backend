using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Common;

namespace AddisEats.Api.Services.OrderServices;

public interface IOrderService
{
    List<Order> GetAllOrders (string OrderLocation , int page , int pageSize);

    Order? GetOrderById (int id);

    Result<Order> CreateNewOrder(CreateOrderDto createOrderDto);
    
}