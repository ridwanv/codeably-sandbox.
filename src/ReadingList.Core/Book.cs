namespace ReadingList.Core;

public sealed record Book(Guid Id, string Title, string Author, int Pages);
