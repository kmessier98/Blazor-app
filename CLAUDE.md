# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

LibraryApp is a French-language library management app (`Application de gestion de bibliothèque`, éducatif). It is a .NET 10 solution with a Blazor WebAssembly client and an ASP.NET Core Web API backend, using EF Core 10 against SQL Server.

The solution lives under `LibraryApp/` (`LibraryApp/LibraryApp.slnx`), not at the repo root.

## Commands

Run these from `LibraryApp/` (where `LibraryApp.slnx` lives):

- `dotnet build LibraryApp.slnx` — build the whole solution
- `dotnet run --project LibraryApp.Api` — run the API (backend)
- `dotnet run --project LibraryApp.Client` — run the Blazor WASM client (frontend)

Both projects must be running at once for the app to work end-to-end. The client's `HttpClient` base address is hardcoded in `LibraryApp.Client/Program.cs` to `https://localhost:7120` (the API's `https` launch profile), and the API's CORS policy (`PermettreClient` in `LibraryApp.Api/Program.cs`) only allows `https://localhost:7142` (the client's `https` launch profile). Use the `https` launch profile for both, or update both places together if ports change.

There is no test suite and no lint command configured in this repository (the `npm`/`vite` commands sometimes suggested by tooling do not apply here — this is a pure .NET solution).

EF Core migrations live in `LibraryApp.Infrastructure/Data/Migrations`. Configure the connection string in `LibraryApp.Api/appsettings.json` (`ConnectionStrings:DefaultConnection`) before running migrations against SQL Server:
- `dotnet ef migrations add <Name> --project LibraryApp.Infrastructure --startup-project LibraryApp.Api`
- `dotnet ef database update --project LibraryApp.Infrastructure --startup-project LibraryApp.Api`

In development, the API exposes Swagger UI and Scalar (`/scalar`) via OpenAPI, generated from `LibraryApp.Api.http`/`AddOpenApi()` in `Program.cs`.

## Architecture

Layered/Clean-Architecture style, with dependencies flowing inward:

- **`LibraryApp.Client`** — Blazor WebAssembly frontend. Pages under `Pages/` are split into a `.razor` (markup) + `.razor.cs` (code-behind, `partial class`) + `.razor.css` (scoped styles). Pages call typed HTTP services in `Services/` (implementing interfaces from `Services/Interfaces/`), which are registered as `Scoped` in `Program.cs`.
- **`LibraryApp.Api`** — ASP.NET Core Web API. Thin `Controllers/` that only call into `Application` services and return `ActionResult`s — no business logic here. `Middlewares/ExceptionHandlingMiddleware` centrally maps `Application.Exceptions` types to HTTP status codes (see below).
- **`LibraryApp.Application`** — business logic layer. `Services/` implement `Interfaces/I*Service` (validate input, apply business rules, call repositories, map to DTOs via AutoMapper). `Validators/` are FluentValidation validators for DTOs, registered in `Program.cs` via `AddValidatorsFromAssembly`. `Mapping/MappingProfile` is the single AutoMapper profile for entity↔DTO mapping across the whole app.
- **`LibraryApp.Domain`** — POCO entities (`Entities/`) with EF Core `[Table(...)]` attributes, no behavior.
- **`LibraryApp.Infrastructure`** — EF Core `Data/AppDbContext` and `Data/Migrations`, plus `Repositories/` implementing `Application.Interfaces/I*Repository` (pure data access, no business rules).
- **`LibraryApp.Shared`** — DTOs (`DTOs/`) referenced by both `Client` and `Api`/`Application`, so request/response shapes stay in sync across the wire without duplication.

Domain model: `Membre` (member) has many `Emprunt` (loans); `Livre` (book) belongs to one `Editeur` (publisher) and has many `Auteur`s and `Categorie`s (many-to-many) and many `Emprunt`s. An active loan is one where `Emprunt.DateRetour == null`.

### Error handling convention

Application-layer code throws typed exceptions from `LibraryApp.Application.Exceptions` (`NotFoundException`, `ConflictException`, `BusinessRuleException`, `UnauthorizedAppException`, all deriving from abstract `AppException`) or lets FluentValidation's `ValidationException` propagate. Do not catch these in controllers — `ExceptionHandlingMiddleware` catches them centrally and converts them to the matching HTTP status code (404, 409, 400, etc.) with a consistent JSON error shape. Follow this pattern for new business rules rather than returning ad-hoc error responses from controllers.

### Client-side service convention

Client services in `LibraryApp.Client/Services` wrap `HttpClient` calls and never let exceptions escape to pages. Reads (e.g. `GetAll`) swallow errors and return an empty/default value, logging via `ILogger<T>`. Writes (e.g. `Create`) return a `ServiceResult<T>` (`Models/ServiceResult.cs`) that carries either the created data or a list of error strings parsed from the API's JSON error body (`Models/ApiErrorResponse.cs`), so pages can render validation/conflict errors inline without try/catch.
