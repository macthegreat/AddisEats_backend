using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Models;
using AddisEats.Api.Services.MenuItemServices;

[ApiController]
[Route("api/V1/[controller]")]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        this.menuItemService = menuItemService;
    }
[HttpGet]
    public ActionResult<List<MenuItem>> GetMenuItems()
    {
        return Ok(menuItemService.GetMenuItems());
    }

    [HttpGet("{id}")]
    public ActionResult<MenuItem> GetMenuItem(int id)
    {
        var menuItem = menuItemService.GetMenuItemById(id);
        if (menuItem == null)
        {
            return NotFound();
        }
        return Ok(menuItem);
    }

}