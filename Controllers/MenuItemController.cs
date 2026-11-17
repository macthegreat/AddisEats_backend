using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Models;
using AddisEats.Api.Services.MenuItemServices;
using System.Runtime.CompilerServices;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

    public class MenuItemController : ControllerBase
{
    
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet()]
    public IActionResult GetAll([FromQuery] string? Category)
    {
        
        var result = _menuItemService.GetAll(Category);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var menuItem = _menuItemService.GetById(id);
        if(menuItem == null)
        {
            return NoContent();
        }
        return Ok(menuItem);
    }
    
}


