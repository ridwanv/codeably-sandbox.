# 2026-11-24-906fa — verbatim from the ticket

Add-book form with validation

Every block below is copied byte for byte out of the ticket. Nothing here is a summary; the segment id is the ticket's own anchor.

## segment 1 (ticket lines 1–1)

Size: medium. Depends on the Books page.

## segment 2 (ticket lines 3–3)

On `/books`, add a form to add a book: Title (required, max 200 chars), Author (required, max 120 chars), Pages (required, 1–10000). Use `EditForm` with a model class carrying DataAnnotations and `DataAnnotationsValidator` + `ValidationMessage` per field. On valid submit, call `BookCatalog.Add`, clear the form and show the new book in the list immediately (interactive server render mode).

## segment 3 (ticket lines 5–5)

Add a `ReadingList.Web.Tests` project (xUnit v3 + bUnit) with tests for: valid submit adds the book; invalid input shows validation messages and adds nothing.

## segment 4 (ticket lines 7–10)

## Acceptance criteria
- Valid submissions appear in the list without a page reload
- Invalid submissions show per-field messages and do not call the catalog
- New bUnit tests pass; `dotnet test --solution ReadingList.slnx` is green
