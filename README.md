# ASP.NET Core Minimal API — Middleware Practice

University coursework exploring request middleware, dependency injection, validation, and an in-memory item repository.

## What it demonstrates

- Creating and retrieving items with GUID identifiers, names and prices.
- Request identifiers, timing/logging middleware and centralized error handling.
- Domain exceptions and a thread-safe in-memory repository.

## Run

Requires the .NET 8 SDK. From the repository root:

```sh
dotnet restore FrameworksPractice1.sln
dotnet run --project FrameworksPractice1 -- --urls http://localhost:5000
```

```sh
curl -X POST http://localhost:5000/api/items -H "Content-Type: application/json" -d '{"name":"Notebook","price":12.50}'
```

Read the returned item with `GET /api/items/{id}`. Empty names and negative prices produce validation errors. Data is lost when the process stops.

## Structure

`Domain/` contains models, `Services/` implements storage, `Middlewares/` handles requests, and `Errors/` defines domain exceptions; all are under `FrameworksPractice1/`.

The project file references `properties/launchSettings.json`, while the tracked directory is `Properties/`. Correct that casing if building on a case-sensitive filesystem. This is a learning project, with no persistent database or authentication layer.
