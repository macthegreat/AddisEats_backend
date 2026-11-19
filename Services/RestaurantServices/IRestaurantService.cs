using AddisEats.Api.Models;
using AddisEats.Api.DTOs;

public interface IRestaurantService
{
    PagedResultDto<RestaurantDto> GetAllRestaurants(RetaurantQuery query);
    
    Restaurant? GetRestaurantById(int id);

    List<Restaurant> Search(string? Name);

    List<MenuItem> GetMenu(int RestaurantId);

    Restaurant CreateRestaurant(CreateRestaurantDto createRestaurantDto);

}