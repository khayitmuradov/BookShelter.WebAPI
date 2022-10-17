using BookShelter.WebAPI.DbContexts;
using BookShelter.WebAPI.Interfaces.Repositories;
using BookShelter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace BookShelter.WebAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbOptions;

    public UserRepository(ApplicationDbContext appDbContext)
    {
        this._dbOptions = appDbContext;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _dbOptions.Users.FindAsync(id);
        _dbOptions.Users.Remove(user);
    }

    public async Task<IQueryable<User>> GetAllAsync()
    {
        return _dbOptions.Users.Where(x => true);
    }

    public async Task<User> GetAsync(int id)
    {
        var user = await _dbOptions.Users.FindAsync(id);
        return user;
    }

    public async Task<User> UpdateAsync(int id, User user)
    {
        user.Id = id;
        _dbOptions.Users.Update(user);
        await _dbOptions.SaveChangesAsync();

        return user;
    }

    public async Task<User> FindByEmail(string email)
    {
        return await _dbOptions.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User> FindByPhoneNumber(string phoneNumber)
    {
        return await _dbOptions.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
    }

    public async Task<User> CreateAsync(User user)
    {
        await _dbOptions.Users.AddAsync(user);
        await _dbOptions.SaveChangesAsync();
        return user;
    }
}
