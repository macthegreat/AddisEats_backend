using AddisEats.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using AddisEats.Api.DTOs;
using AddisEats.Api.Data;

namespace AddisEats.Api.Services.MenuItemServices;

public class MenuitemService : IMenuItemService
{
    //List of menu items
   private static readonly List<MenuItem> _menuitem = SeedData.menuItems;
    private static int _index = 12;
    public List<MenuItem> GetAll(string? Category)
    {

        var items = _menuitem.Where(m => Category == null || m.Category == Category).ToList();
        return items;

    }

    public MenuItem? GetById(int id)
    {
        var result = _menuitem.FirstOrDefault(m => m.Id == id);
        return result;
    }
    public MenuItem CreateNewMenuItem(CreateMenuItemDto createMenuItemDto)
    {
        MenuItem menuItem = new MenuItem
        {
            Id = _index++,
            RestaurantId=createMenuItemDto.RestaurantId,
            Name = createMenuItemDto.Name,
            Category = createMenuItemDto.Category,
            Price =createMenuItemDto.Price,


        };

        _menuitem.Add(menuItem);
        return menuItem;
       
    }
}