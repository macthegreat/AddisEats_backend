using AddisEats.Api.Data;
using AddisEats.Api.DTOs;
using AddisEats.Api.Models;

namespace AddisEats.Api.Services.UserServices;

public class UserService : IUserService
{
    private static readonly List<User> _user = SeedData.listOfusers;
    private static int _next = 1;

    public List<User> GetAllUsers()
    {
        return _user;
    }

    public User GetUserById(int id)
    {
        var result = _user.FirstOrDefault(m=> m.Id == id);
        return result;
    }

    public User CreateNewUser(CreateUserDto createUserDto)
    {
        User user = new User
        {
            Id=_next++,
            FullName = createUserDto.FullName,
            Phone =createUserDto.Phone,
            PasswordHash =createUserDto.Password,
            Role = createUserDto.Role
        };
        
         _user.Add(user);
         return user;
    }


}