using AddisEats.Api.Models;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.OrderServices;

public interface IOrderService
{
    List<Order> GetAllOrders (string OrderLocation , int page , int pageSize);

    Order? GetOrderById (int id);

    Order CreateNewOrder(CreateOrderDto createOrderDto);
    
}