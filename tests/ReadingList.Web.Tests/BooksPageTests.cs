using Bunit;
using Microsoft.Extensions.DependencyInjection;
using ReadingList.Core;
using ReadingList.Web.Components.Pages;
using ReadingList.Web.Models;

namespace ReadingList.Web.Tests;

public sealed class BooksPageTests
{
    private const string ValidTitle = "Dune";
    private const string ValidAuthor = "Frank Herbert";
    private const int ValidPages = 412;

    [Fact]
    public void Submit_ValidInput_AddsBookShowsItInListAndClearsForm()
    {
        using var ctx = new BunitContext();
        var catalog = new BookCatalog();
        ctx.Services.AddSingleton(catalog);
        var cut = ctx.Render<Books>();

        FillForm(cut, ValidTitle, ValidAuthor, ValidPages.ToString());
        cut.Find("form").Submit();

        var book = Assert.Single(catalog.All());
        Assert.Equal(ValidTitle, book.Title);
        Assert.Equal(ValidAuthor, book.Author);
        Assert.Equal(ValidPages, book.Pages);
        Assert.Contains(ValidTitle, cut.Find("tbody").TextContent);
        Assert.True(string.IsNullOrEmpty(cut.Find("#title").GetAttribute("value")));
        Assert.True(string.IsNullOrEmpty(cut.Find("#author").GetAttribute("value")));
        Assert.True(string.IsNullOrEmpty(cut.Find("#pages").GetAttribute("value")));
    }

    [Fact]
    public void Submit_BoundaryInput_AddsBook()
    {
        using var ctx = new BunitContext();
        var catalog = new BookCatalog();
        ctx.Services.AddSingleton(catalog);
        var cut = ctx.Render<Books>();

        FillForm(
            cut,
            new string('a', NewBookModel.TitleMaxLength),
            new string('b', NewBookModel.AuthorMaxLength),
            NewBookModel.PagesMax.ToString());
        cut.Find("form").Submit();

        Assert.Single(catalog.All());
        Assert.Empty(cut.FindAll(".validation-message"));
    }

    [Fact]
    public void Submit_EmptyInput_ShowsFieldMessagesAndAddsNothing()
    {
        using var ctx = new BunitContext();
        var catalog = new BookCatalog();
        ctx.Services.AddSingleton(catalog);
        var cut = ctx.Render<Books>();

        cut.Find("form").Submit();

        var messages = cut.FindAll(".validation-message").Select(m => m.TextContent).ToList();
        Assert.Contains(NewBookModel.TitleRequiredMessage, messages);
        Assert.Contains(NewBookModel.AuthorRequiredMessage, messages);
        Assert.Contains(NewBookModel.PagesRequiredMessage, messages);
        Assert.Empty(catalog.All());
    }

    [Fact]
    public void Submit_OutOfRangeInput_ShowsFieldMessagesAndAddsNothing()
    {
        using var ctx = new BunitContext();
        var catalog = new BookCatalog();
        ctx.Services.AddSingleton(catalog);
        var cut = ctx.Render<Books>();

        FillForm(
            cut,
            new string('a', NewBookModel.TitleMaxLength + 1),
            new string('b', NewBookModel.AuthorMaxLength + 1),
            (NewBookModel.PagesMax + 1).ToString());
        cut.Find("form").Submit();

        var messages = cut.FindAll(".validation-message").Select(m => m.TextContent).ToList();
        Assert.Contains(NewBookModel.TitleTooLongMessage, messages);
        Assert.Contains(NewBookModel.AuthorTooLongMessage, messages);
        Assert.Contains(NewBookModel.PagesOutOfRangeMessage, messages);
        Assert.Empty(catalog.All());
    }

    private static void FillForm(IRenderedComponent<Books> cut, string title, string author, string pages)
    {
        cut.Find("#title").Change(title);
        cut.Find("#author").Change(author);
        cut.Find("#pages").Change(pages);
    }
}
