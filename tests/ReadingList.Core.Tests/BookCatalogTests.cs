namespace ReadingList.Core.Tests;

public sealed class BookCatalogTests
{
    [Fact]
    public void Add_StoresTrimmedBook()
    {
        var catalog = new BookCatalog();

        var book = catalog.Add("  Dune ", " Frank Herbert ", 412);

        Assert.Equal("Dune", book.Title);
        Assert.Equal("Frank Herbert", book.Author);
        Assert.Single(catalog.All());
    }

    [Fact]
    public void All_IsSortedByTitle()
    {
        var catalog = new BookCatalog();
        catalog.Add("neuromancer", "William Gibson", 271);
        catalog.Add("Dune", "Frank Herbert", 412);

        Assert.Equal(["Dune", "neuromancer"], catalog.All().Select(b => b.Title));
    }

    [Theory]
    [InlineData("", "Author", 10)]
    [InlineData("Title", " ", 10)]
    [InlineData("Title", "Author", 0)]
    public void Add_RejectsInvalidInput(string title, string author, int pages) =>
        Assert.ThrowsAny<ArgumentException>(() => new BookCatalog().Add(title, author, pages));
}
