# Plan: 2026-11-24-906fa Add-book form with validation

Files changed and the done line each serves:

- `src/ReadingList.Web/Models/NewBookModel.cs` (new): DataAnnotations model, Title max 200, Author max 120, Pages 1-10000, all required. Serves: invalid submissions show per-field messages.
- `src/ReadingList.Web/Components/Pages/Books.razor`: `@rendermode InteractiveServer`, EditForm with DataAnnotationsValidator and ValidationMessage per field; a valid submit calls `BookCatalog.Add`, refreshes the list and resets the model. Serves: valid submissions appear without a reload; invalid ones do not call the catalog.
- `tests/ReadingList.Web.Tests/` (new project, xUnit v3 + bUnit) with `BooksPageTests.cs`: valid submit, empty input, out-of-range input. Serves: new bUnit tests pass.
- `ReadingList.slnx`: the new test project is added. Serves: `dotnet test --solution ReadingList.slnx` is green.
