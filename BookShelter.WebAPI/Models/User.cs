namespace BookShelter.WebAPI.Models;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public UserRole.UserRole UserRole { get; set; } = WebAPI.UserRole.UserRole.User;

    public string Email { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;
}
