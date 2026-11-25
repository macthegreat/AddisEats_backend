using AddisEats.Api.DTOs;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Services.UserServices;
using AddisEats.Api.Mappers;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _Userservice;

    public UserController(IUserService userService)
    {
        _Userservice = userService;
    }
    
    [HttpGet()]
    public IActionResult GetAllUsers()
    {
        var allUsers = _Userservice.GetAllUsers();

        return Ok(allUsers);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _Userservice.GetUserById(id);

        if(user == null)
        {
            return NotFound();
        }
        return Ok(user.toUserDto());
    }


    [HttpPost()]
    public IActionResult CreateNewUser(CreateUserDto createUserDto)
    {
        var newUser = _Userservice.CreateNewUser(createUserDto);
        return CreatedAtAction(nameof(GetUserById), new{id = newUser.Id}, newUser.toUserDto());
    }


}