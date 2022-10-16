using BookShelter.WebAPI.Commons.Enums;

namespace BookShelter.WebAPI.Models;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AuthorFullName { get; set; } = string.Empty;

    public string PublishedYear { get; set; } = string.Empty;

    public string Publisher { get; set; } = string.Empty;

    public Categories Category { get; set; }

    public int PagesCount { get; set; }
}
