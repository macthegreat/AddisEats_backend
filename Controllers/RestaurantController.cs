using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Models;
using AddisEats.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AddisEats.Api.Mappers;
using AddisEats.Api.Services.MenuItemServices;
using AddisEats.Api.DTOs;


namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMenuItemService _menuItemService;

    public RestaurantController(IRestaurantService restaurantService, IMenuItemService menuItemService)
    {
        _restaurantService = restaurantService;
        _menuItemService = menuItemService;
    }

    [HttpGet()]
    public IActionResult GetAllRestaurants([FromQuery] RetaurantQuery query)
    {
        var restaurants = _restaurantService.GetAllRestaurants(query);
        //var restaurantDto = restaurants.Select(r => r.ToDto()).ToList();
        return Ok(restaurants);
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

    [HttpGet("{RestaurantId}/menu")]
    public IActionResult GetMenu(int RestaurantId )
    {
        if (_menuItemService.GetById(RestaurantId) == null)
        {
            return NotFound();
        }
        var item = _restaurantService.GetMenu(RestaurantId)
        .Where(m => m.RestaurantId == RestaurantId).ToList();
        
        return Ok(item);
    }
    [HttpPost()]
    public IActionResult CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
    {
        var newRstaurant = _restaurantService.CreateRestaurant(createRestaurantDto);
        return CreatedAtAction(nameof(GetRestaurantById),new{id = newRstaurant.Id},newRstaurant);
    }
}