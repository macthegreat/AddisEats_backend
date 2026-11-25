namespace AddisEats.Api.Configurations;

public class JwtOptions
{
    public string Issuer {get;set;}=string.Empty;
    public string Audience {get;set;} =string.Empty;
    public string SigningKey {get;set;} =string.Empty;
    public int AccessTokenMinute {get;set;} = 15;
    
}