using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using AddisEats.Api.Data;
using AddisEats.Api.Models;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace AddisEats.Api.Validation;

public class PasswordAttribute : ValidationAttribute
{

private static readonly Regex regex = new (@"^[a-zA-Z0-9]{6,}$");

public PasswordAttribute()
    {
        ErrorMessage ="enter a password with length of 6";
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value is null)
        {
            return ValidationResult.Success;
        }
        if(value is not string password || !regex.IsMatch(password))
        {
            return new ValidationResult(ErrorMessage);
        }
        return ValidationResult.Success;
    } 
}
