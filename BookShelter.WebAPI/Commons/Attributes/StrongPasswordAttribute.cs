using BookShelter.WebAPI.Commons.Validators;
using System.ComponentModel.DataAnnotations;

namespace BookShelter.WebAPI.Commons.Attributes;
#nullable disable
[AttributeUsage(AttributeTargets.Property)]
public class StrongPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null)
            return new ValidationResult("Password cannot be Null");
        else
        {
            string password = value.ToString();
            if (password.Length < 8)
            {
                return new ValidationResult("Password must be at least 8 Characters");
            }
            else if (password.Length > 50)
            {
                return new ValidationResult("Password must be less than 50 Characters");
            }

            var result = PasswordValidator.IsStrong(password);

            if (result.IsValid is false)
                return new ValidationResult(result.Message);
            else return ValidationResult.Success;
        }
    }
}
