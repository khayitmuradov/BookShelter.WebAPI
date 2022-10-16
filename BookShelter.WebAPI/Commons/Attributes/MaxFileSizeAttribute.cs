using BookShelter.WebAPI.Commons.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BookShelter.WebAPI.Commons.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly int _maxFileSize;
    public MaxFileSizeAttribute(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file is not null)
        {
            // fileSizeHelper is basically a generator, generates byte to megabyte
            if (FileSizeHelper.ByteToMegabyte(file.Length) > _maxFileSize)
                return new ValidationResult($"Image Size must be less than {_maxFileSize} MB");
            else
                return ValidationResult.Success;
        }
        else
            return new ValidationResult("The File cannot be Null!");
    }
}
