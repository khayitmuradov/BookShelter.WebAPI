using BookShelter.WebAPI.Models;

namespace BookShelter.WebAPI.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetAsync(int id);

    Task<IQueryable<User>> GetAllAsync();

    Task CreateAsync(User user);

    Task<User> UpdateAsync(int id, User user);

    Task DeleteAsync(int id);

    Task<User> FindByEmail(string email);

    Task<User> FindByPhoneNumber(string phoneNumber);
}
