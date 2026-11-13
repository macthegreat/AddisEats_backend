using AddisEats.Api.Services.RestaurantServices;
using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Mappers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/V1/[controller]")]

public class RestaurantController : ControllerBase
{
    //dependency injection for restaurant service
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet("{id}")]
    public IActionResult GetRestaurantsById(int id)
    {
        var restaurant = _restaurantService.GetById(id);
        var restaurantDto = restaurant?.ToDto();
            if(restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurantDto);
        }

        [HttpGet()]
        public IActionResult GetAllRestaurants([FromQuery] string? address, [FromQuery] int page = 1, [FromQuery] int pageSize = 3)
        {
            var restaurants = _restaurantService.GetAll(address, page, pageSize);
            var restaurantDtos = restaurants.Select(r => r.ToDto()).ToList();
            return Ok(restaurantDtos);
        }
        
   
        
    }
    
