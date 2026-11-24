---
name: ticket-5
description: Show the current year in a footer using TimeProvider — last green run 2026-11-24T16-33-53-50a3
metadata:
  type: project
---

# Ticket 5: Show the current year in a footer using TimeProvider

- Last green run: 2026-11-24T16-33-53-50a3
- Changed 4 source file(s): src/ReadingList.Web/Components/Layout/MainLayout.razor, src/ReadingList.Web/Program.cs, tests/ReadingList.Web.Tests/FixedTimeProvider.cs, tests/ReadingList.Web.Tests/MainLayoutTests.cs
- Key decisions:
  - [scope] Complexity tier: small — cost cap sized to $5 / 500,000 tokens
  - [scope] Work shape: mixed — Mostly mechanical edits (footer markup, DI registration), with a bounded pocket of judgement in setting up the bUnit test project and fake T…
