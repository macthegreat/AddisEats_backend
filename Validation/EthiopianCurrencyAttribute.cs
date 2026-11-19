using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AddisEats.Api.Validation;

public class EthiopianCurrencyAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value is null)
        {
            return ValidationResult.Success;
        }
        if(value is not decimal amount || amount <= 0)
        {
            return new ValidationResult("Amount must be greater than zero");
        }
        if(decimal.Round(amount,2) != amount)
        {
            return new ValidationResult("amount can not have more than two decimal place");
        }
        return ValidationResult.Success;
    }
}

