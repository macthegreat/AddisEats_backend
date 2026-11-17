using AddisEats.Api.Models;
using AddisEats.Api.Data;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    
private readonly List<Restaurant> restaurants = SeedData.restaurants;
    
    public List<Restaurant> GetAllRestaurants(string? Location, int page, int pageSize)
    {
        var result = restaurants.Where(x =>Location ==null || x.Location ==Location)
        .OrderBy(r=>r.Name)
        .Skip((page -1) *pageSize)
        .Take(pageSize)
        .ToList();

        return result;
    }

    public Restaurant? GetRestaurantById(int id)
    {
       var result = restaurants.FirstOrDefault(x => x.Id ==id);
       return result;
    }

    public List<Restaurant> Search(string? Name)
    {
        var results = restaurants.Where(s => Name == null || s.Name ==Name).ToList();
        return results;
    }


}