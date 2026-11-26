using AddisEats.Api.Data;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace AddisEats.Api.Services.UserServices;

public class DemoUserService
{
    private readonly List<User> users = SeedData.listOfusers;

    public DemoUserService(IPasswordHasher<User> passwordHasher)
    {
        var customer = new User
        {
            Id = 1,
            FullName ="Beza Nega",
            Phone ="0911122334",
            IsVerified =true
        
        };
        
        customer.PasswordHash = passwordHasher.HashPassword(customer, "bez@123");
        users.Add(customer);
    }

public User? findByPhone(string Phone)
    {
        return users.FirstOrDefault(p => p.Phone == Phone); 
    }
}