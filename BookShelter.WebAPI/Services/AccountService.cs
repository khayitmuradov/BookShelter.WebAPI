using BookShelter.WebAPI.Commons.Exceptions;
using BookShelter.WebAPI.Interfaces.Managers;
using BookShelter.WebAPI.Interfaces.Repositories;
using BookShelter.WebAPI.Interfaces.Services;
using BookShelter.WebAPI.Models;
using BookShelter.WebAPI.Security;
using BookShelter.WebAPI.ViewModels.Users;

namespace BookShelter.WebAPI.Services;

public class AccountService : IAccountService
{
    private readonly IUserRepository _repository;
    private readonly IAuthManager _authManager;
    private readonly IFileService _fileService;

    public AccountService(IUserRepository repository, IAuthManager authManager, IFileService fileService)
    {
        _repository = repository;
        _authManager = authManager;
        _fileService = fileService;
    }

    public async Task<string> LoginAsync(UserLoginViewModel userLoginViewModel)
    {
        var user = await _repository.FindByEmail(userLoginViewModel.Email);
        if (user is null) throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Email is wrong!");

        var hasherResult = PasswordHasher.Verify(userLoginViewModel.Password, user.Salt, user.PasswordHash);
        if (hasherResult is false) throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Password is wrong!");

        return _authManager.GenerateToken(user);
    }

    public async Task<bool> RegistrationAsync(UserCreateViewModel userCreateViewModel)
    {
        var validateUser = await _repository.FindByEmail(userCreateViewModel.Email);
        if (validateUser is not null) throw new StatusCodeException(System.Net.HttpStatusCode.Conflict, "This email is already exist");

        validateUser = await _repository.FindByPhoneNumber(userCreateViewModel.PhoneNumber);
        if (validateUser is not null) throw new StatusCodeException(System.Net.HttpStatusCode.Conflict, "This phone number is already exist");

        var user = (User)userCreateViewModel;
        if (userCreateViewModel.Image is not null)
            user.ImagePath = await _fileService.SaveImageAsync(userCreateViewModel.Image);
        var hasherResult = PasswordHasher.Hash(userCreateViewModel.Password);
        user.Salt = hasherResult.Salt;
        user.PasswordHash = hasherResult.Hash;
        await _repository.CreateAsync(user);
        return true;
    }
}
