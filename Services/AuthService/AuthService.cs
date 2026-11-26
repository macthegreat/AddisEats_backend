
using System.Security.Claims;
using AddisEats.Api.Configurations;
using AddisEats.Api.Models;
using Microsoft.Extensions.Options;
// dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;



namespace AddisEats.Api.Services.AuthService;

public class AuthService
{
    private readonly JwtOptions _options;

    public AuthService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string CreateAccessToken(User user)
    {
       Claim[] claims =
    [
        new Claim(
            JwtRegisteredClaimNames.Sub,
            user.Id.ToString()
        ),
        new Claim(
            JwtRegisteredClaimNames.Jti,
            Guid.NewGuid().ToString()
        ),
        new Claim(
            ClaimTypes.Name,
            user.FullName
        ),
        new Claim(
            ClaimTypes.Role,
            user.Role
        ),
        new Claim(
            "IsVerified",
            user.IsVerified ? "true" : "false"
        )
    ];


        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.SigningKey));

        var Credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        
        var Token = new JwtSecurityToken(
            issuer : _options.Issuer,
            audience : _options.Audience,
            claims : claims,
            expires : DateTime.UtcNow.AddMinutes(_options.AccessTokenMinute), signingCredentials : Credentials

        );
        return new JwtSecurityTokenHandler().WriteToken(Token);
      
    }
}




