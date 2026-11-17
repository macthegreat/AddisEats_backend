using AddisEats.Api.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AddisEats.Api.Services.MenuItemServices;

public interface IMenuItemService
{
    List<MenuItem> GetAll(string? Category);
      MenuItem? GetById(int id);
}