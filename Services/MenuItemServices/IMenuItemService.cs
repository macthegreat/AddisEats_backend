using AddisEats.Api.Models;

namespace AddisEats.Api.Services.MenuItemServices;
public interface IMenuItemService
{
    List<MenuItem> GetMenuItems();
    MenuItem GetMenuItemById(int id);
}