using AddisEats.Api.Models;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.RestaurantServices;
public interface IRestaurantService
{
    Restaurant? GetById(int id);
    List<Restaurant> GetAll(string? address, int page, int pageSize);

    Task CreateRestaurant(CreateRestaurantDto createRestaurantDto);

}