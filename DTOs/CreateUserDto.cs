using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Models;
using AddisEats.Api.Validation;

namespace AddisEats.Api.DTOs;

public record CreateUserDto
(
    [StringLength(20,MinimumLength =3 ,ErrorMessage ="name must be at least 3 characters")]
    string FullName,
    [EthiopianMobile]
    string Phone,
    [Required]
    string Password,
    [Password]
    string Role

);
