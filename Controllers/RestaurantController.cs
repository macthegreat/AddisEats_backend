using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Models;
using AddisEats.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AddisEats.Api.Mappers;


namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet()]
    public IActionResult GetAllRestaurants([FromQuery] string? Location, int page=1,int pageSize = 3)
    {
        var restaurants = _restaurantService.GetAllRestaurants(Location ,page ,pageSize);
        var restaurantDto = restaurants.Select(r => r.ToDto()).ToList();
        return Ok(restaurantDto);
    } 

    [HttpGet("{id}")]
    public IActionResult GetRestaurantById(int id)
    {
        var restaurant = _restaurantService.GetRestaurantById(id);

        if(restaurant == null)
        {
            return NotFound();
        }
        return Ok(restaurant.ToDto());
    }
}