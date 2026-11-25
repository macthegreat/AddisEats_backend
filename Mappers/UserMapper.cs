using AddisEats.Api.DTOs;
using AddisEats.Api.Models;

namespace AddisEats.Api.Mappers;

public static class UserMapper
{
    public static UserResponseDto toUserDto ( this User user)
    {
        return new UserResponseDto(
            user.Id,
            user.FullName,
            user.Role
        );
    }
}