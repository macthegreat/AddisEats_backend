namespace AddisEats.Api.DTOs;

public record RestaurantDto
(
   int Id,
   string Name,
string Location,
    string PhoneNumber,
    bool IsActive
);