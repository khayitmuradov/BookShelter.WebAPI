using BookShelter.WebAPI.Commons.Enums;
using BookShelter.WebAPI.Models;

namespace BookShelter.WebAPI.ViewModels.Books;

public class BookViewModel
{
    public string Title { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AuthorFullName { get; set; } = string.Empty;

    public string PublishedYear { get; set; } = string.Empty;

    public Categories Category { get; set; }

    public int PagesCount { get; set; }

    public static implicit operator BookViewModel(Book book)
    {
        return new BookViewModel()
        {
            ImagePath = book.ImagePath,
            Title = book.Title,
            Description = book.Description,
            AuthorFullName = book.AuthorFullName,
            PublishedYear = book.PublishedYear,
            Category = book.Category,
            PagesCount = book.PagesCount,
        };
    }
}
