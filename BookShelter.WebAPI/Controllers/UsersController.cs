using BookShelter.WebAPI.Commons.Utils;
using BookShelter.WebAPI.Interfaces.Services;
using BookShelter.WebAPI.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShelter.WebAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }


    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        var result = await _service.GetAllAsync(@params);
        return Ok(result);
    }

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<IActionResult> GetAsync(int id)
    {
        var result = await _service.GetAsync(id);
        return StatusCode(result.statusCode, result.user);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] UserUpdateViewModel userUpdateViewModel)
    {
        var result = await _service.UpdateAsync(id, userUpdateViewModel);
        return StatusCode(result.statusCode, result.message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _service.DeleteAsync(id);
        return StatusCode(result.statusCode, result.message);
    }
}
