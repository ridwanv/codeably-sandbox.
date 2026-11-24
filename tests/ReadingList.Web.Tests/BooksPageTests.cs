using Bunit;
using Microsoft.Extensions.DependencyInjection;
using ReadingList.Core;
using ReadingList.Web.Components.Pages;

namespace ReadingList.Web.Tests;

public sealed class BooksPageTests
{
    [Fact]
    public void Submit_ValidInput_AddsBookAndShowsItInList()
    {
        using var ctx = new BunitContext();
        var catalog = new BookCatalog();
        ctx.Services.AddSingleton(catalog);
        var cut = ctx.Render<Books>();

        cut.Find("#title").Change("Dune");
        cut.Find("#author").Change("Frank Herbert");
        cut.Find("#pages").Change("412");
        cut.Find("form").Submit();

        var book = Assert.Single(catalog.All());
        Assert.Equal("Dune", book.Title);
        Assert.Contains("Dune", cut.Find("tbody").TextContent);
        Assert.Equal(string.Empty, cut.Find("#title").GetAttribute("value") ?? string.Empty);
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
        Assert.Contains("Title is required.", messages);
        Assert.Contains("Author is required.", messages);
        Assert.Contains("Pages is required.", messages);
        Assert.Empty(catalog.All());
    }

    [Fact]
    public void Submit_OutOfRangeInput_ShowsFieldMessagesAndAddsNothing()
    {
        using var ctx = new BunitContext();
        var catalog = new BookCatalog();
        ctx.Services.AddSingleton(catalog);
        var cut = ctx.Render<Books>();

        cut.Find("#title").Change(new string('a', 201));
        cut.Find("#author").Change(new string('b', 121));
        cut.Find("#pages").Change("10001");
        cut.Find("form").Submit();

        var messages = cut.FindAll(".validation-message").Select(m => m.TextContent).ToList();
        Assert.Contains("Title must be at most 200 characters.", messages);
        Assert.Contains("Author must be at most 120 characters.", messages);
        Assert.Contains("Pages must be between 1 and 10000.", messages);
        Assert.Empty(catalog.All());
    }
}
