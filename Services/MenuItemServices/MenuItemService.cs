using AddisEats.Api.Models;
using AddisEats.Api.Services.MenuItemServices;

namespace AddisEats.Api.Services.MenuItemServices;
public class MenuItemService : IMenuItemService
{
    private List<MenuItem> menuItems;

    public MenuItemService()
    {
        menuItems = new List<MenuItem>
        {
            new MenuItem(1, "Spaghetti Bolognese", "Main Course", 12.99m),
            new MenuItem(2, "Caesar Salad", "Salad", 8.99m),
            new MenuItem(3, "Tiramisu", "Dessert", 6.99m)
        };
    }

    public List<MenuItem> GetMenuItems()
    {
        return menuItems;
    }

    public MenuItem GetMenuItemById(int id)
    {
        return menuItems.FirstOrDefault(x => x.Id == id);
    }
}