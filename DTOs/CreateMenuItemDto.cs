using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Models;
using AddisEats.Api.Validation;

namespace AddisEats.Api.DTOs;

public record CreateMenuItemDto (
    [Required(ErrorMessage ="id is required")]
    int Id,
    [Required(ErrorMessage ="Name is required")]
    [StringLength(50,MinimumLength = 3 ,ErrorMessage = "minlength for name is 3 characters")]
    string Name,
    [Required(ErrorMessage ="category is required")]
    string Category,
    [Required(ErrorMessage ="price is required")]
    [EthiopianCurrency]
    decimal Price,
    [Range(1,100,ErrorMessage ="restaurant id must be between 1 and 100")]
    int RestaurantId

);