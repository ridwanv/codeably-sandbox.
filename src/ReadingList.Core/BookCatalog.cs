using System.Collections.Concurrent;

namespace ReadingList.Core;

/// <summary>In-memory book catalog. Thread-safe; state lives for the lifetime of the instance.</summary>
public sealed class BookCatalog
{
    private readonly ConcurrentDictionary<Guid, Book> _books = new();

    public IReadOnlyList<Book> All() =>
        [.. _books.Values.OrderBy(b => b.Title, StringComparer.OrdinalIgnoreCase)];

    public Book Add(string title, string author, int pages)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(author);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pages);

        var book = new Book(Guid.NewGuid(), title.Trim(), author.Trim(), pages);
        _books[book.Id] = book;
        return book;
    }
}
