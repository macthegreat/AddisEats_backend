using System.ComponentModel.DataAnnotations;

namespace AddisEats.Api.DTOs;
public record CreateOrderDto(
    [Range(1,int.MaxValue,ErrorMessage ="Restaurant id must be a posetive integer")]
    int RestaurantId,
    int menuItemId,
    string CustomerName,
    string DeliveryAddress,
    string Customerphone,
    int Quantity,
    decimal TotalAmount
);