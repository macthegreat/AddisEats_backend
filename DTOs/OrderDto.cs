using AddisEats.Api.Models;

namespace AddisEats.Api.DTOs;

public record OrderDto(
  
    int MenuItemId,
    string CustomerName,
    string Orderlocation
);