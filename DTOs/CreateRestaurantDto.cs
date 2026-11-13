using AddisEats.Api.Models;
namespace AddisEats.Api.DTOs;

public record CreateRestaurantDto(

string Name,
string Location,
string PhoneNumber,
bool IsActive,
string OwnerAddress


);

