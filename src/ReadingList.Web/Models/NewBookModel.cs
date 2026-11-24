using System.ComponentModel.DataAnnotations;

namespace ReadingList.Web.Models;

public sealed class NewBookModel
{
    public const int TitleMaxLength = 200;
    public const int AuthorMaxLength = 120;
    public const int PagesMin = 1;
    public const int PagesMax = 10000;

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(TitleMaxLength, ErrorMessage = "Title must be at most 200 characters.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Author is required.")]
    [StringLength(AuthorMaxLength, ErrorMessage = "Author must be at most 120 characters.")]
    public string? Author { get; set; }

    [Required(ErrorMessage = "Pages is required.")]
    [Range(PagesMin, PagesMax, ErrorMessage = "Pages must be between 1 and 10000.")]
    public int? Pages { get; set; }
}
