\# Farouq's Record Shop API



A backend REST API for managing a record shop inventory system. Built with ASP.NET Core, Entity Framework Core, and SQL Server.

\---



\## Overview



The Record Shop needed a way to manage their album inventory digitally. This API provides a full set of endpoints to store, query, update and delete album records — replacing the old paper-based system.



The project follows a clean MVC architecture with clear separation of concerns across the Controller, Service and Repository layers, and is fully unit tested.



\---



\## Tech Stack



\- \*\*ASP.NET Core (.NET 8)\*\* — Web API framework

\- \*\*Entity Framework Core\*\* — ORM for database access

\- \*\*SQL Server\*\* — Production database

\- \*\*In-Memory Database\*\* — Used in development and testing

\- \*\*NUnit + Shouldly + Moq\*\* — Unit testing

\- \*\*Swagger\*\* — API documentation (available in development mode)



\---



\## Getting Started



\### Prerequisites



\- Visual Studio 2022

\- .NET 8 SDK

\- SQL Server (the project uses `SQLEXPRESS` locally)

\- Postman (for testing endpoints)



\### Setup



1\. Clone the repository:

git clone https://github.com/FarouqAbdul93/FarouqsRecordShop.git



2\. Open the solution in Visual Studio 2022.



3\. Update the connection string in `appsettings.json` and `appsettings.Production.json` to point to your SQL Server instance.



4\. Run the migrations to create the database:

Update-Database



5\. Set `ASPNETCORE\_ENVIRONMENT` to `Production` in the launch profile to use SQL Server, or leave it as `Development` to use the in-memory database.



6\. Run the application.



\---



\## Endpoints



\### Albums



| Method | Endpoint | Description |

|--------|----------|-------------|

| GET | `/api/album` | Get all albums |

| GET | `/api/album/{id}` | Get album by ID |

| POST | `/api/album` | Add a new album |

| PUT | `/api/album/{id}` | Update an album |

| DELETE | `/api/album/{id}` | Delete an album |



\### Filtering



| Method | Endpoint | Description |

|--------|----------|-------------|

| GET | `/api/album/artist/{artist}` | Get albums by artist |

| GET | `/api/album/genre/{genre}` | Get albums by genre |

| GET | `/api/album/year/{year}` | Get albums by release year |

| GET | `/api/album/name/{title}` | Get album by name |



\### Health



| Method | Endpoint | Description |

|--------|----------|-------------|

| GET | `/health` | Check API and database health |



\---



\## Project Structure

FarouqsRecordShop/

├── Controllers/        # Handles HTTP requests and responses

├── Services/           # Business logic layer

├── Repository/         # Data access layer

├── Models/             # Album model and DbContext

├── Middleware/         # Error handling middleware

├── Migrations/         # EF Core database migrations

FarouqsRecordShop.Tests/

├── ControllerTests/    # Unit tests for controllers

├── ServiceTests/       # Unit tests for services

├── RepositoryTests/    # Unit tests for repositories

RecordShopCLI/          # Command-line interface for the API



\---



\## Testing



The project has 35 unit tests covering all layers of the application. To run the tests, use the Test Explorer in Visual Studio or run:

dotnet test



\---



\## CLI Interface



A command-line interface is included in the `RecordShopCLI` project. It allows users to interact with the API directly from the terminal — searching for albums by artist, genre, year or name.



To use it, make sure the API is running first, then start the CLI project.



\---



\## Assumptions \& Decisions



\- Albums are the only resource in this version of the API. Artists and genres are stored as simple strings on the album rather than as separate linked entities.

\- The in-memory database is used in development and resets on every app restart — this is intentional for testing purposes.

\- Seed data is added on startup if the database is empty, so there are always some albums to work with out of the box.

\- Error responses return a JSON object with a message field to give the client meaningful feedback beyond just a status code.



\---



\## Future Thoughts



\- \*\*Frontend\*\* — A frontend application is currently in development and will be connected to this API.

\- \*\*Authentication\*\* — Adding JWT authentication to protect write endpoints (POST, PUT, DELETE).

\- \*\*Pagination\*\* — For larger inventories, paginating the GET all albums response would be beneficial.

\- \*\*Artists and Genres as entities\*\* — Normalising the data by giving artists and genres their own tables and relationships.

\- \*\*Purchase endpoint\*\* — An endpoint to handle purchasing an album and automatically updating the stock count.



\---



\## Author



Farouq Abdul — \[GitHub](https://github.com/FarouqAbdul93)

