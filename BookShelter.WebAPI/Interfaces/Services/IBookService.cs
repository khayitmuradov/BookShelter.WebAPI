using BookShelter.WebAPI.Commons.Utils;
using BookShelter.WebAPI.ViewModels.Books;

namespace BookShelter.WebAPI.Interfaces.Services;

public interface IBookService
{
    Task<IEnumerable<BookViewModel>> GetAllAsync(PaginationParams @params);

    Task<(int statusCode, BookViewModel book, string message)> GetAsync(int id);

    Task<(int statusCode, string message)> CreateAsync(BookCreateViewModel bookCreateViewModel);

    Task<(int statusCode, string message)> UpdateAsync(int id, BookUpdateViewModel bookUpdateViewModel);

    Task<(int statusCode, string message)> DeleteAsync(int id);
}
