using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
namespace AddisEats.Api.Mappers;

public static class RestaurantMapper
{
    public static RestaurantDto ToDto(this Restaurant restaurant)
    {
        return new RestaurantDto(
            restaurant.Id,
            restaurant.Name,
            restaurant.Location,
            restaurant.PhoneNumber,
            restaurant.IsActive
        );
    }
    public static RestaurantDto ToMenuItemDto(this Restaurant restaurant)
    {

        return new RestaurantDto(
            
            restaurant.Id,
            restaurant.Name,
            restaurant.Location,
            restaurant.PhoneNumber,
            restaurant.IsActive

        );
    }
}