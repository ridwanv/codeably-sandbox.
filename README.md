# codeably-sandbox.

A Blazor Server (.NET 10) **Reading List** app, built out by AgentSmith (codeably) from GitHub issues.

```bash
dotnet build ReadingList.slnx
dotnet test --solution ReadingList.slnx
dotnet run --project src/ReadingList.Web
```

| Project | Purpose |
|---|---|
| `src/ReadingList.Web` | Blazor Server UI (interactive server render mode) |
| `src/ReadingList.Core` | Domain: books and the catalog |
| `tests/ReadingList.Core.Tests` | xUnit v3 tests for the core |
