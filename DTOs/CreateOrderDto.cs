using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Validation;

namespace AddisEats.Api.DTOs;
public record CreateOrderDto(
    
    [Range(1,int.MaxValue,ErrorMessage ="Restaurant id must be a posetive integer")]
    int RestaurantId,
    int menuItemId,
    [Required (ErrorMessage = "Customer name is required.")]
    string CustomerName,
    [StringLength(30,MinimumLength = 3 ,ErrorMessage = "min length should be 3 characters")]
    string DeliveryAddress,
    [Required (ErrorMessage = "phone number is required")]
    [EthiopianMobile]
    string Customerphone,
    [Range(1,50,ErrorMessage = " quantity should be between 1 and 50")]
    int Quantity,
    decimal TotalAmount

);