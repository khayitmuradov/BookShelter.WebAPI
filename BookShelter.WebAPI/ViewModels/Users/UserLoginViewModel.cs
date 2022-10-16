using BookShelter.WebAPI.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BookShelter.WebAPI.ViewModels.Users;

public class UserLoginViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
           ErrorMessage = "Please enter valid email")]
    public string Email { get; set; } = String.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StrongPassword]
    public string Password { get; set; } = String.Empty;
}
