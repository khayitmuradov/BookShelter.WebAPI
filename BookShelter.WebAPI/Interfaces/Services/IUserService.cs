using BookShelter.WebAPI.Commons.Utils;
using BookShelter.WebAPI.ViewModels.Users;

namespace BookShelter.WebAPI.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params);

    Task<(int statusCode, UserViewModel user, string message)> GetAsync(int id);

    Task<(int statusCode, string message)> UpdateAsync(int id, UserUpdateViewModel userUpdateViewModel);

    Task<(int statusCode, string message)> DeleteAsync(int id);
}
