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

    [HttpGet("{RestaurantId}/menu")]
    public IActionResult GetMenu(int RestaurantId )
    {
        if (_menuItemService.GetById(RestaurantId) == null)
        {
            return NotFound();
        }
        var item = _restaurantService.GetMenu(RestaurantId).Where(m => m.RestaurantId == RestaurantId).ToList();
        var itemDto = item;
        return Ok(item);
    }
}