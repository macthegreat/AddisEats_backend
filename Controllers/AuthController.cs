
using AddisEats.Api.DTOs;
using AddisEats.Api.Models;
using AddisEats.Api.Services.AuthService;
using AddisEats.Api.Services.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class AuthController : ControllerBase
{
    private readonly DemoUserService _demoUserService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthService _authService;

    public AuthController(DemoUserService demoUserService,IPasswordHasher<User> passwordHasher, AuthService authService)
    {
        _demoUserService = demoUserService;
        _passwordHasher = passwordHasher;
        _authService = authService;
    }
     [HttpPost()]
     public IActionResult Login(LoginDto request)
    {
        var user = _demoUserService.findByPhone(request.Phone);
        if(user is null)
        {
            return Unauthorized(
                new {message="invalid credential"
        });
        }
        var result =_passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.PasswordHash
            
        );
        if(result == PasswordVerificationResult.Failed)
        {
            return Unauthorized(new
            {
                Message = "invalid password"
            });
        }
        var accessToken = _authService.CreateAccessToken(user);
            
        var response = new LoginResponseDto
        {
            AccessToken = accessToken,
            TokenType = "Bearer",
            ExpiresAtUtc =DateTime.Now.AddMinutes(15)
        };

        return Ok(response);

    }
}
