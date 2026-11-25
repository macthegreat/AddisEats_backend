using AddisEats.Api.Models;

namespace AddisEats.Api.DTOs;

public record LoginDto(
    string Phone,
    string PasswordHash
);