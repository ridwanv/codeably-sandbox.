# 2026-11-24-90a2a — verbatim from the ticket

Persist books in SQLite with EF Core

Every block below is copied byte for byte out of the ticket. Nothing here is a summary; the segment id is the ticket's own anchor.

## segment 1 (ticket lines 1–1)

Size: large.

## segment 2 (ticket lines 3–3)

Replace the in-memory `BookCatalog` storage with EF Core + SQLite so books survive an app restart.

## segment 3 (ticket lines 5–9)

- Add `ReadingListDbContext` (in `ReadingList.Core` or a new `ReadingList.Data` project) with a `Books` set; configure `Book` with Title/Author max lengths matching the form validation.
- Keep `BookCatalog` as the service the UI uses, now backed by the DbContext (use `IDbContextFactory<ReadingListDbContext>` — Blazor Server circuits are long-lived, so do not inject a scoped DbContext into components). Make its methods async (`AllAsync`, `AddAsync`) and update the UI.
- Connection string `Data Source=readinglist.db` in appsettings; apply migrations at startup in Development only.
- Add an initial EF Core migration.
- Tests run against SQLite in-memory (`DataSource=:memory:` with an open connection), not the EF InMemory provider.

## segment 4 (ticket lines 11–14)

## Acceptance criteria
- Added books are still listed after restarting the app
- No repository abstraction over the DbContext
- All tests green, including updated BookCatalog tests
