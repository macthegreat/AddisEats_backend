using AddisEats.Api.Models;
using AddisEats.Api.Data;
using AddisEats.Api.DTOs;
using AddisEats.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{

    private static readonly List<Restaurant> restaurants = SeedData.restaurants;
    private static int _index = 1;
    private readonly List<MenuItem> menuItems = SeedData.menuItems;

    public PagedResultDto<RestaurantDto> GetAllRestaurants(RetaurantQuery query)
    {
        var result = restaurants.Where(x => query.Address == null || x.Location == query.Address)
        .Where(x => query.Name == null || x.Name == query.Name)
        .Where(x => query.IsActive == null || x.IsActive == query.IsActive)
        .OrderBy(r => r.Name)
        .ToList();

        var totalCount = result.Count();

        var toReturn = result
        .Skip((1 - query.Page) * query.PageSize)
        .Take(query.PageSize)
        .ToList();

        PagedResultDto<RestaurantDto> pagedResultDto = new PagedResultDto<RestaurantDto>
        {

            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize,
            Data = toReturn.Select(x => x.ToDto()).ToList()

        };

        return pagedResultDto;
    }
    public Restaurant? GetRestaurantById(int id)
    {
        var result = restaurants.FirstOrDefault(x => x.Id == id);
        return result;
    }

    public List<Restaurant> Search(string? Name)
    {
        var results = restaurants.Where(s => Name == null || s.Name == Name).ToList();
        return results;
    }

    public List<MenuItem> GetMenu(int RestaurantId)
    {
        var menuResult = menuItems.Where(m => m.RestaurantId == RestaurantId).ToList();
        return menuItems;
    }

    public Restaurant CreateRestaurant(CreateRestaurantDto createRestaurantDto)
    {
        Restaurant restaurant = new Restaurant
        {
            Id = _index++,
            Name = createRestaurantDto.Name,
            Location = createRestaurantDto.Location,
            PhoneNumber = createRestaurantDto.PhoneNumber,
            IsActive = createRestaurantDto.IsActive,
            OwnerAddress = createRestaurantDto.OwnerAddress
        };
        restaurants.Add(restaurant);

        return restaurant;
    }

}