﻿using BookShelter.WebAPI.Commons.Utils;
using BookShelter.WebAPI.Interfaces.Repositories;
using BookShelter.WebAPI.Interfaces.Services;
using BookShelter.WebAPI.Models;
using BookShelter.WebAPI.Security;
using BookShelter.WebAPI.ViewModels.Users;

namespace BookShelter.WebAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService;

    public UserService(IUserRepository repository, IFileService fileService)
    {
        this._repository = repository;
        this._fileService = fileService;
    }

    public async Task<(int statusCode, string message)> CreateAsync(UserCreateViewModel userCreateViewModel)
    {
        var user = (User)userCreateViewModel;
        if (userCreateViewModel.Image is not null)
        {
            user.ImagePath = await _fileService.SaveImageAsync(userCreateViewModel.Image);
        }
        var hasherResult = PasswordHasher.Hash(userCreateViewModel.Password);
        user.Salt = hasherResult.Salt;
        user.PasswordHash = hasherResult.Hash;
        await _repository.CreateAsync(user);

        return (statusCode: 200, message: "");
    }

    public async Task<(int statusCode, string message)> DeleteAsync(int id)
    {
        var user = await _repository.GetAsync(id);
        if (user is null)
            return (statusCode: 404, message: "User not Found!");
        else
        {
            await _repository.DeleteAsync(id);
            return (statusCode: 200, message: "");
        }
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        var users = (await _repository.GetAllAsync()).Skip(@params.GetSkipCount()).Take(@params.PageSize);
        var userviewmodels = new List<UserViewModel>();
        foreach (var user in users)
        {
            var userviewmodel = (UserViewModel)user;
            userviewmodels.Add(userviewmodel);
        }
        return userviewmodels;
    }

    public async Task<(int statusCode, UserViewModel user, string message)> GetAsync(int id)
    {
        var user = await _repository.GetAsync(id);
        if (user is null) return (statusCode: 404, user: (UserViewModel)new User(), message: "User not found");
        else return (statusCode: 200, user: user, message: "");
    }

    public async Task<(int statusCode, string message)> UpdateAsync(int id, UserUpdateViewModel userUpdateViewModel)
    {
        var user = await _repository.GetAsync(id);
        if (user is null) return (statusCode: 404, message: "User not found");
        else
        {
            var userNew = (User)userUpdateViewModel;
            await _repository.UpdateAsync(id, userNew);
            return (statusCode: 200, message: "");
        }
    }
}
