using AddisEats.Api.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.MenuItemServices;

public interface IMenuItemService
{
    List<MenuItem> GetAll(string? Category);
    MenuItem? GetById(int id);

    MenuItem CreateNewMenuItem(CreateMenuItemDto createMenuItemDto);
}