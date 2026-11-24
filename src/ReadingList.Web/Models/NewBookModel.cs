using System.ComponentModel.DataAnnotations;

namespace ReadingList.Web.Models;

public sealed class NewBookModel
{
    public const int TitleMaxLength = 200;
    public const int AuthorMaxLength = 120;
    public const int PagesMin = 1;
    public const int PagesMax = 10000;

    // Messages are literals: C# const interpolation cannot take int holes, and attributes need constants.
    public const string TitleRequiredMessage = "Title is required.";
    public const string TitleTooLongMessage = "Title must be at most 200 characters.";
    public const string AuthorRequiredMessage = "Author is required.";
    public const string AuthorTooLongMessage = "Author must be at most 120 characters.";
    public const string PagesRequiredMessage = "Pages is required.";
    public const string PagesOutOfRangeMessage = "Pages must be between 1 and 10000.";

    [Required(ErrorMessage = TitleRequiredMessage)]
    [StringLength(TitleMaxLength, ErrorMessage = TitleTooLongMessage)]
    public string? Title { get; set; }

    [Required(ErrorMessage = AuthorRequiredMessage)]
    [StringLength(AuthorMaxLength, ErrorMessage = AuthorTooLongMessage)]
    public string? Author { get; set; }

    [Required(ErrorMessage = PagesRequiredMessage)]
    [Range(PagesMin, PagesMax, ErrorMessage = PagesOutOfRangeMessage)]
    public int? Pages { get; set; }
}
