using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Models;
using AddisEats.Api.Validation;

namespace AddisEats.Api.DTOs;

public class LoginDto{
    [Required]
    [EthiopianMobile]
    public string Phone {get;set;} = string.Empty;
    [Required] 
    [Password]  
    public string PasswordHash {get; set;} =string.Empty;

}
