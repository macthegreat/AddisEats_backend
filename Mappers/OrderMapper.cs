using AddisEats.Api.DTOs;
using AddisEats.Api.Models;

namespace AddisEats.Api.Mappers;

public static class OrderMapper{
    public static OrderDto ToOrderDto(this Order order)
    {
        return new OrderDto(
           
            order.MenuItemId,
            order.CustomerName,
            order.OrderLocation

        );
    }
}