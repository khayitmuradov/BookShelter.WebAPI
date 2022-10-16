using BookShelter.WebAPI.Models;

namespace BookShelter.WebAPI.ViewModels.Users;

public class UserViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public static implicit operator UserViewModel(User user)
    {
        return new UserViewModel()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            ImagePath = user.ImagePath,
        };
    }
}
