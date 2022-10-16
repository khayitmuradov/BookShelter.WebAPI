using BookShelter.WebAPI.Models;

namespace BookShelter.WebAPI.Interfaces.Managers;

public interface IAuthManager
{
    public string GenerateToken(User user);
}
