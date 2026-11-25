using AddisEats.Api.Data;
using AddisEats.Api.Models;

namespace AddisEats.Api.DTOs;

public record UserResponseDto(

    int Id,
    string FullNmae,
    string Role

);


