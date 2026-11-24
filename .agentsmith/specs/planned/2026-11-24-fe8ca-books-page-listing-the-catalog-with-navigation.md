# 2026-11-24-fe8ca — verbatim from the ticket

Books page listing the catalog, with navigation

Every block below is copied byte for byte out of the ticket. Nothing here is a summary; the segment id is the ticket's own anchor.

## segment 1 (ticket lines 1–1)

Size: small.

## segment 2 (ticket lines 3–3)

Add a `/books` page to `ReadingList.Web` that lists every book in `BookCatalog` in a table (Title, Author, Pages), sorted as `BookCatalog.All()` returns them. When the catalog is empty, show "No books yet." instead of the table.

## segment 3 (ticket lines 5–5)

Add a simple navigation bar to `MainLayout` with links to Home (`/`) and Books (`/books`), using `NavLink` so the active page is highlighted.

## segment 4 (ticket lines 7–10)

## Acceptance criteria
- `/books` renders the table, or the empty-state text when there are no books
- MainLayout shows Home and Books links on every page
- `dotnet build` has no warnings; existing tests still pass
