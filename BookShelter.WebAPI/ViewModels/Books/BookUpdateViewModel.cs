using BookShelter.WebAPI.Commons.Attributes;
using BookShelter.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BookShelter.WebAPI.ViewModels.Books;

public class BookUpdateViewModel
{
    [Required]
    [MaxLength(100), MinLength(2)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxFileSize(5)]
    [DataType(DataType.Upload)]
    [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
    public IFormFile Image { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    [MinLength(50)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is Required")]
    [MaxLength(75), MinLength(2)]
    [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
        ErrorMessage = "Please Enter Valid Name. " +
        "Name Must be Contain only Letters or ' character")]
    public string AuthorFullName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.DateTime)]
    [RegularExpression("[0-9]{4}")]
    public string PublishedYear { get; set; } = string.Empty;

    public int PagesCount { get; set; }

    public static implicit operator Book(BookUpdateViewModel bookUpdateViewModel)
    {
        return new Book()
        {
            Title = bookUpdateViewModel.Title,
            AuthorFullName = bookUpdateViewModel.AuthorFullName,
            PublishedYear = bookUpdateViewModel.PublishedYear,
            Description = bookUpdateViewModel.Description,
            PagesCount = bookUpdateViewModel.PagesCount,
        };
    }
}
