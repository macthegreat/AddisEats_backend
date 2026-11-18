using AddisEats.Api.Models;

public interface IRestaurantService
{
    List<Restaurant> GetAllRestaurants(string? Location, int page, int pageSize);
    Restaurant? GetRestaurantById(int id);

    List<Restaurant> Search(string? Name);

    List<MenuItem> GetMenu(int RestaurantId);

}