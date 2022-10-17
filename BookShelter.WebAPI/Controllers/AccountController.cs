using BookShelter.WebAPI.Interfaces.Services;
using BookShelter.WebAPI.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShelter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost("regstrate"), AllowAnonymous]
    public async Task<IActionResult> RegistrateAsync([FromForm] UserCreateViewModel userCreateViewModel)
        => Ok(await _service.RegistrationAsync(userCreateViewModel));

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] UserLoginViewModel userLoginViewModel)
        => Ok(new { Token = await _service.LoginAsync(userLoginViewModel) });
}
