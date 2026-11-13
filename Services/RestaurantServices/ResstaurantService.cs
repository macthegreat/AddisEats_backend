using AddisEats.Api.Models;
using AddisEats.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    private readonly List<Restaurant> allrestaurants = SeedData.restaurants;
    public Restaurant? GetById(int id)
    {
        return allrestaurants.Where(r => r.Id == id).FirstOrDefault();
    }
    public List<Restaurant> GetAll(string? address,  int page ,int pageSize)
    {
        var restaurant = allrestaurants
        .Where(r => address == null || r.Location == address )
        .OrderBy(r => r.Name)
        .Skip((page -1) * pageSize)
        .Take(pageSize)
        .ToList();
        return restaurant;
    }

    

  
}