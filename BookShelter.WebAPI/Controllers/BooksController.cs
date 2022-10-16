using BookShelter.WebAPI.Commons.Utils;
using BookShelter.WebAPI.Interfaces.Services;
using BookShelter.WebAPI.ViewModels.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
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
        return StatusCode(result.statusCode, result.book);
    }

    [HttpPost, Authorize(Roles = "User, Admin, SupaAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] BookCreateViewModel bookCreateViewModel)
    {
        var result = await _service.CreateAsync(bookCreateViewModel);
        return StatusCode(result.statusCode, result.message);
    }

    [HttpPut, Authorize(Roles = "User, Admin, SupaAdmin"), AllowAnonymous]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] BookUpdateViewModel bookUpdateViewModel)
    {
        var result = await _service.UpdateAsync(id, bookUpdateViewModel);
        return StatusCode(result.statusCode, result.message);
    }

    [HttpDelete("{id}"), Authorize(Roles = "User, Admin, SupaAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _service.DeleteAsync(id);
        return StatusCode(result.statusCode, result.message);
    }
}
