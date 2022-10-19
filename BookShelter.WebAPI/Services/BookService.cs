using BookShelter.WebAPI.Commons.Utils;
using BookShelter.WebAPI.DbContexts;
using BookShelter.WebAPI.Interfaces.Repositories;
using BookShelter.WebAPI.Interfaces.Services;
using BookShelter.WebAPI.Models;
using BookShelter.WebAPI.ViewModels.Books;

namespace BookShelter.WebAPI.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly ApplicationDbContext _dbContext;
    private readonly IFileService _fileService;

    public BookService(IBookRepository repository, ApplicationDbContext dbContext, IFileService fileService)
    {
        _repository = repository;
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<(int statusCode, string message)> CreateAsync(BookCreateViewModel bookCreateViewModel)
    {
        var book = (Book)bookCreateViewModel;
        if (bookCreateViewModel.Image is not null)
        {
            book.ImagePath = await _fileService.SaveImageAsync(bookCreateViewModel.Image);
            await _repository.CreateAsync(book);
        }

        return (statusCode: 200, message: "");
    }

    public async Task<(int statusCode, string message)> DeleteAsync(int id)
    {
        var book = await _repository.GetAsync(id);
        if (book == null)
        {
            return (statusCode: 404, message: "Book not found!");
        }
        else
        {
            await _repository.DeleteAsync(id);
            await _dbContext.SaveChangesAsync();
            return (statusCode: 200, message: "");
        }
    }

    public async Task<IEnumerable<BookViewModel>> GetAllAsync(PaginationParams @params)
    {
        var books = (await _repository.GetAllAsync()).Skip(@params.GetSkipCount()).Take(@params.PageSize);
        var bookviewmodels = new List<BookViewModel>();
        foreach (var book in books)
        {
            var bookviewmodel = (BookViewModel)book;
            bookviewmodels.Add(bookviewmodel);
        }
        return bookviewmodels;
    }

    public async Task<(int statusCode, BookViewModel book, string message)> GetAsync(int id)
    {
        var book = await _repository.GetAsync(id);
        if (book is null) return (statusCode: 404, book: (BookViewModel)new Book(), message: "Book not found");
        else return (statusCode: 200, book: book, message: "");
    }

    public async Task<(int statusCode, string message)> UpdateAsync(int id, BookUpdateViewModel bookUpdateViewModel)
    {
        var book = await _repository.GetAsync(id);
        if (book is null) return (statusCode: 404, message: "Book not found");
        else
        {
            var bookNew = (Book)bookUpdateViewModel;
            await _repository.UpdateAsync(id, bookNew);
            return (statusCode: 200, message: "");
        }
    }
}
