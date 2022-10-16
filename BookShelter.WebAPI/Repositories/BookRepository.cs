using BookShelter.WebAPI.DbContexts;
using BookShelter.WebAPI.Interfaces.Repositories;
using BookShelter.WebAPI.Models;
#nullable disable
namespace BookShelter.WebAPI.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbOptions;

    public BookRepository(ApplicationDbContext appDb)
    {
        _dbOptions = appDb;
    }

    public async Task CreateAsync(Book book)
    {
        await _dbOptions.Books.AddAsync(book);
        await _dbOptions.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _dbOptions.Books.FindAsync(id);
        _dbOptions.Books.Remove(book);
    }

    public async Task<IQueryable<Book>> GetAllAsync()
    {
        return  _dbOptions.Books.Where(x => true);
    }

    public async Task<Book> GetAsync(int id)
    {
        var book = await _dbOptions.Books.FindAsync(id);
        return book;
    }

    public async Task<Book> UpdateAsync(int id, Book book)
    {
        book.Id = id;
        _dbOptions.Books.Update(book);
        await _dbOptions.SaveChangesAsync();

        return book;
    }
}
