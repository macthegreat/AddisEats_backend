using AddisEats.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AddisEats.Api.Services.MenuItemServices;

public class MenuitemService : IMenuItemService
{
    //List of menu items
    private readonly List<MenuItem> _menuitem = new List<MenuItem>()
    {
      new MenuItem {Id=1,Category="Main-course",Name ="shiro" ,Price =230m, RestaurantId=1},
      new MenuItem {Id = 2,Category ="Traditional-Dish",Name ="DoroWet", Price=1280m,RestaurantId=3},
      new MenuItem {Id= 3 , Category = "fasting", Name="Cotelet",Price =430m,RestaurantId =1},
      new MenuItem {Id= 4 , Category = "fasting", Name="salad",Price =330m,RestaurantId =1},
      new MenuItem {Id=5 ,}

      
    };

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
}