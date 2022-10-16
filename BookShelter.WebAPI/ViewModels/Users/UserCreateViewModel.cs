using BookShelter.WebAPI.Commons.Attributes;
using BookShelter.WebAPI.Models;
using System.ComponentModel.DataAnnotations;
namespace BookShelter.WebAPI.ViewModels.Users;

public class UserCreateViewModel
{
    [Required(ErrorMessage = "First Name is Required")]
    [MaxLength(50), MinLength(2)]
    [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
        ErrorMessage = "Please Enter Valid Name. " +
        "Name Must Contains only Letters or ' character")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is Required")]
    [MaxLength(50), MinLength(2)]
    [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
        ErrorMessage = "Please Enter Valid Name. " +
        "Name Must be Contain only Letters or ' character")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(250), MinLength(25)]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$",
        ErrorMessage = "Please Enter Valid Phone Number")]
    public string PhoneNumber { get; set; } = string.Empty;

    public UserRole.UserRole UserRole { get; set; } = WebAPI.UserRole.UserRole.User;

    [Required(ErrorMessage = "Email is Required")]
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
    ErrorMessage = "Please Enter Valid Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StrongPassword]
    public string Password { get; set; } = string.Empty;

    [MaxFileSize(3)]
    [DataType(DataType.Upload)]
    [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
    public IFormFile? Image { get; set; } = null!;

    public static implicit operator User(UserCreateViewModel userCreateViewModel)
    {
        return new User()
        {
            FirstName = userCreateViewModel.FirstName,
            LastName = userCreateViewModel.LastName,
            Address = userCreateViewModel.Address,
            PhoneNumber = userCreateViewModel.PhoneNumber,
            UserRole = userCreateViewModel.UserRole,
            Email = userCreateViewModel.Email,
            PasswordHash = userCreateViewModel.Password,
        };
    }
}
