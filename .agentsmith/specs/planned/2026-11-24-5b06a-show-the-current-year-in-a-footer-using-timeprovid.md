# 2026-11-24-5b06a — verbatim from the ticket

Show the current year in a footer using TimeProvider

Every block below is copied byte for byte out of the ticket. Nothing here is a summary; the segment id is the ticket's own anchor.

## segment 1 (ticket lines 1–1)

Size: small.

## segment 2 (ticket lines 3–3)

Add a footer to `MainLayout`: "Reading List © {year}". Get the year from an injected `TimeProvider` (register `TimeProvider.System` as a singleton in `Program.cs`); do not use `DateTime.Now` / `DateTime.UtcNow`.

## segment 3 (ticket lines 5–5)

Add a bUnit test that registers a fake `TimeProvider` fixed to 2030 and asserts the footer shows 2030.

## segment 4 (ticket lines 7–10)

## Acceptance criteria
- Footer visible on every page with the current year
- No `DateTime.Now`/`UtcNow` in the change
- Test with a fixed TimeProvider passes
