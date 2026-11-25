using AddisEats.Api.Models;

namespace AddisEats.Api.DTOs;

public record CreateUserDto
(
    
    string FullName,
    string Phone,
    string Password,
    string Role

);
