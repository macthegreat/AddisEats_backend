using AddisEats.Api.Models;

namespace AddisEats.Api.DTOs;

public record CreateMenuItemDto (

    int Id,
    string Name,
    string Category,
    decimal Price,
    int RestaurantId

);