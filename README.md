# Farouq's Record Shop API

A backend REST API for managing a record shop inventory system. Built with ASP.NET Core, Entity Framework Core, and SQL Server as part of the Northcoders Enterprise Engineering Bootcamp (C# / .NET).

---

## Overview

This API provides a full set of endpoints to create, read, update, and delete album records. It follows a clean layered architecture with clear separation of concerns across Controller, Service, and Repository layers, and is fully unit tested.

A Blazor frontend is available here: [FarouqsRecordShopUI](https://github.com/FarouqAbdul93/FarouqsRecordShopUI)

---

## Tech Stack

- **ASP.NET Core (.NET 8)** — Web API framework
- **Entity Framework Core** — ORM for database access
- **SQL Server** — Production database
- **In-Memory Database** — Used in development and testing
- **JWT Authentication** — Secure endpoint protection
- **NUnit + Shouldly + Moq** — Unit testing (35 passing tests)
- **Swagger** — API documentation (available in development mode)

---

## Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 8 SDK
- SQL Server (the project uses `SQLEXPRESS` locally)
- Postman or Swagger for testing endpoints

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/FarouqAbdul93/FarouqsRecordShop.git
   ```

2. Open the solution in Visual Studio 2022.

3. Update the connection string in `appsettings.json` to point to your SQL Server instance:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=RecordShopDb;..."
   }
   ```

4. Run the EF Core migrations to create the database:
   ```
   Update-Database
   ```

5. Set `ASPNETCORE_ENVIRONMENT` to `Production` in your launch profile to use SQL Server, or leave it as `Development` to use the in-memory database with seed data.

6. Run the application. Swagger UI will be available at `https://localhost:7090/swagger`.

---

## API Endpoints

Base URL: `https://localhost:7090/api/album`

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/album` | Get all albums |
| GET | `/api/album/{id}` | Get a single album by ID |
| POST | `/api/album` | Add a new album |
| PUT | `/api/album/{id}` | Update an existing album |
| DELETE | `/api/album/{id}` | Delete an album |

### Filtering Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/album?artist={name}` | Filter by artist |
| GET | `/api/album?genre={genre}` | Filter by genre |
| GET | `/api/album?year={year}` | Filter by release year |
| GET | `/api/album?name={name}` | Search by album name (substring match) |

### Other Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/health` | Health check |

---

## Album Model

```json
{
  "id": 1,
  "title": "The Documentary",
  "artist": "The Game",
  "genre": "Hip-Hop",
  "releaseYear": 2005
}
```

---

## Running the Tests

Open the Test Explorer in Visual Studio 2022 and run all tests, or use the CLI:

```
dotnet test
```

35 unit tests covering the Service and Repository layers using NUnit, Shouldly, and Moq.

---

## Project Structure

```
FarouqsRecordShop1/
├── Controllers/        # API endpoints
├── Services/           # Business logic
├── Repositories/       # Data access layer
├── Models/             # Album model
├── Data/               # DbContext and seed data
└── Tests/              # NUnit unit tests
```

---

## Author

**Farouq Abdullah**
- GitHub: [FarouqAbdul93](https://github.com/FarouqAbdul93)
- LinkedIn: [farouq-hassan-abdullah](https://linkedin.com/in/farouq-hassan-abdullah)