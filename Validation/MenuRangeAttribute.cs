using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using AddisEats.Api.Data;
using AddisEats.Api.Models;
using Microsoft.VisualBasic;

namespace AddisEats.Api.Validation;

public class MenuRangeAttribute : ValidationAttribute
{
    private static List<MenuItem> menuList =SeedData.menuItems;

    
    

}
