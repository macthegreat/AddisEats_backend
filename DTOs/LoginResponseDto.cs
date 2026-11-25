namespace AddisEats.Api.DTOs;

public class LoginResponseDto
{
    public string AccessToken {get; set;} = string.Empty;
    public string TokenType {get;set;}="Barrier";
    public DateTime ExpiresAtUtc {get;set;}
    
}