using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
namespace AddisEats.Api.Mappers;

public static class CreateRestaurantMapper
{
    public static CreateRestaurantDto ToRestaurantDto(this Restaurant restaurant)
    {
        return new CreateRestaurantDto(
          
            restaurant.Name,
            restaurant.Location,
            restaurant.PhoneNumber,
            restaurant.IsActive,
            restaurant.OwnerAddress
            
        );
    }
}