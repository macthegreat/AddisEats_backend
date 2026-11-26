using AddisEats.Api.Data;
using AddisEats.Api.DTOs;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace AddisEats.Api.Services.UserServices;

public interface IUserService
{
    List<User> GetAllUsers();

    User? GetUserById(int id);

    User CreateNewUser(CreateUserDto createUserDto, IPasswordHasher<User> passwordHasher);

}