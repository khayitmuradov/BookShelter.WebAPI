using BookShelter.WebAPI.ViewModels.Users;

namespace BookShelter.WebAPI.Interfaces.Services;

public interface IAccountService
{
    Task<bool> RegistrationAsync(UserCreateViewModel userCreateViewModel);

    Task<string> LoginAsync(UserLoginViewModel userLoginViewModel);
}
