# Contributing to NIHComicViewerWeb

Thank you for contributing to NIHComicViewerWeb. This document captures project standards, architectural guidelines, and the expectations for code contributions and reviews.

## Table of contents

- Purpose
- Architecture overview
- Dependency injection & DbContext guidance
- Coding standards & formatting
- Branching, PRs and code reviews
- Testing and CI
- Security and secrets
- Performance and resilience
- Architecture review checklist

## Purpose

This repository is a Razor Pages application. The goal of this document is to ensure contributions are consistent, secure, and maintainable.

## Architecture overview

Logical layers:

- UI: Razor Pages under `Pages/` and shared resources under `Pages/Shared`.
- Application: `NIHComicViewer.Application` — application services, models, DTOs, business orchestration.
- Infrastructure: `NIHComicViewer.Infrastructure` — EF Core entities, DbContext, repositories, external integrations.

Guidelines:
- Keep business logic in application services. PageModels should orchestrate UI and call services.
- Use interfaces for cross-layer boundaries and register services with DI.
- Prefer constructor injection and avoid service location.

## Dependency injection & DbContext guidance

Target: .NET 10, EF Core, PostgreSQL.

- Choose one DbContext registration strategy and stay consistent:
  - Use `AddDbContext<TContext>()` when repositories/services depend on `TContext` via constructor injection (recommended for request-scoped operations).
  - Use `AddDbContextFactory<TContext>()` when you need to create DbContext instances on demand (background work, parallelism).
- Do not register `AddDbContextFactory` and resolve `TContext` directly. If using the factory, depend on `IDbContextFactory<TContext>` and call `CreateDbContext()` as needed and dispose it.
- Lifetimes:
  - `DbContext` and DbContext-dependent repositories/services should be `Scoped`.
  - `Singleton` services must not depend on `DbContext`.
- UnitOfWork:
  - If the UnitOfWork constructor requires `TContext`, register `AddDbContext<TContext>()` and `AddScoped<IUnitOfWork, UnitOfWork>()`.
  - If you prefer factory-based creation, make UnitOfWork accept `IDbContextFactory<TContext>` and create/dispose contexts internally.
- Prefer typed HTTP clients via `AddHttpClient<TClient, TImpl>()` for services that use `HttpClient`.

## Coding standards & formatting

- A `.editorconfig` file governs formatting. Ensure your editor honors it.
- Naming:
  - PascalCase for public types/members.
  - camelCase or _camelCase for private fields per `.editorconfig`.
  - Async methods must end with `Async`.
- Keep methods small and single-responsibility. Prefer clear interfaces for services.

## Branching, PRs and code reviews

- Branch naming: `feature/<short>`, `fix/<short>`, `chore/<short>`.
- Open PRs against `master` with a descriptive title and checklist:
  - What changed and why.
  - How to test locally.
  - Any config or secret changes.
- PR checks required:
  - `dotnet build` succeeds.
  - `dotnet test` passes for affected tests.
  - Linting/static analysis passes (if enabled).
- PRs must include tests for new business logic when practical.

## Testing and CI

- Unit tests should not depend on a real database.
- Integration tests that exercise repositories should use ephemeral databases (Testcontainers, local test DB, or controlled test fixtures).
- CI should run build, test, and static analysis steps and use secure environment variables for secrets.

## Security and secrets

- Never commit secrets or credentials. Use `dotnet user-secrets` for local development and a secret store (e.g., Azure Key Vault) for production.
- Validate inputs and avoid exposing sensitive data in logs or responses.

## Performance and resilience

- Keep DbContext lifetimes short.
- Use `EnableRetryOnFailure` with bounded retries/backoff for transient DB errors; avoid unbounded retries.
- Consider `AddDbContextPool<TContext>()` only when you understand pooling implications.

## Architecture review checklist

When reviewing a change, verify:
1. Layer separation is preserved (UI → Application → Infrastructure).
2. DbContext registration matches how it is consumed (`AddDbContext` vs `AddDbContextFactory`).
3. No duplicate/conflicting service registrations.
4. Appropriate service lifetimes (`Scoped` for DbContext consumers).
5. UnitOfWork aligns with chosen DbContext strategy.
6. Connection strings/secrets are not committed and are read from configuration or secret stores.
7. Logging and error handling provide sufficient observability.
8. Tests cover behavioral changes and instructions to run them are in the PR.
9. Razor Pages use `MapRazorPages()` and PageModel responsibilities are thin and focused.
10. Authentication middleware ordering is correct (`UseAuthentication()` before `UseAuthorization()` when used).

## Need help?

I can open a PR adding this file, or produce a suggested `Program.cs` patch to resolve DI mismatches (switch to `AddDbContext` or adapt UnitOfWork/repositories to `IDbContextFactory`).