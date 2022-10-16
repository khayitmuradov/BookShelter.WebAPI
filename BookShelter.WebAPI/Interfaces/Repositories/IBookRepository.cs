using BookShelter.WebAPI.Models;

namespace BookShelter.WebAPI.Interfaces.Repositories;

public interface IBookRepository
{
    Task<Book> GetAsync(int id);

    Task<IQueryable<Book>> GetAllAsync();

    Task CreateAsync(Book book);

    Task<Book> UpdateAsync(int id, Book book);

    Task DeleteAsync(int id);
}
