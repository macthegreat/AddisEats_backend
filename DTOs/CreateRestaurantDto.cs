using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Models;
using AddisEats.Api.Validation;
namespace AddisEats.Api.DTOs;

public record CreateRestaurantDto(
[Required(ErrorMessage ="Name is required")]
string Name,
[StringLength(20,MinimumLength = 5 ,ErrorMessage = "location should be 5 chars minimum ")]
string Location,
[Required(ErrorMessage ="Phone is required")]
[EthiopianMobile]
string PhoneNumber,
bool IsActive,
[Required(ErrorMessage = " ownwers address is required")]
string OwnerAddress

);

