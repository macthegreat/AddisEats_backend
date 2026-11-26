using AddisEats.Api.Data;
using AddisEats.Api.DTOs;
using AddisEats.Api.Mappers;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace AddisEats.Api.Services.UserServices;

public class UserService : IUserService
{
    private static readonly List<User> _user = SeedData.listOfusers;
    private static int _next = 1;

    public List<User> GetAllUsers()
    {
       var allUsers =_user.OrderBy(n =>n.FullName).ToList();
       return allUsers;
    }

    public User GetUserById(int id)
    {
        var result = _user.FirstOrDefault(m=> m.Id == id);
        return result;
    }

    public User CreateNewUser(CreateUserDto createUserDto , IPasswordHasher<User> passwordHasher)
    {
        User user = new User
        {
            Id=_next++,
            FullName = createUserDto.FullName,
            Phone =createUserDto.Phone,
            
            PasswordHash =createUserDto.Password,
            Role = createUserDto.Role
        };
        user.PasswordHash =passwordHasher.HashPassword(user, user.PasswordHash);
    
         _user.Add(user);
         return user;
    }


}