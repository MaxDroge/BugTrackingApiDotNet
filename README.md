# Bug Tracking API (.NET)

This project is a RESTful API built with **C# and ASP.NET Core** for managing and tracking software bugs. It allows users to create, retrieve, update, and delete bug reports while maintaining structured workflow data such as status and priority.

## Features

* Create bug reports
* View all bugs
* View a single bug by ID
* Update bug details (title, description, status, priority)
* Delete bug reports
* Validate workflow fields (status and priority)
* Interactive API documentation with Swagger

## Tech Stack

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Swagger (OpenAPI)

## Project Structure

```
BugTrackingApiDotNet/
├── Controllers/
│   └── BugsController.cs
├── Data/
│   └── BugDbContext.cs
├── Models/
│   └── Bug.cs
├── DTOs/
│   ├── CreateBugDto.cs
│   └── UpdateBugDto.cs
├── Program.cs
├── appsettings.json
```

## How to Run

1. Install .NET SDK (if not already installed):
   https://dotnet.microsoft.com/download

2. Navigate to the project folder:

   ```
   cd BugTrackingApiDotNet
   ```

3. Run the application:

   ```
   dotnet run
   ```

4. Open Swagger UI in your browser:

   ```
   http://localhost:5000/swagger
   ```

   (Port may vary depending on your environment)

## API Endpoints

### Get all bugs

```
GET /api/bugs
```

### Get bug by ID

```
GET /api/bugs/{id}
```

### Create a bug

```
POST /api/bugs
```

Example request body:

```json
{
  "title": "Login button not working",
  "description": "Clicking login does nothing",
  "priority": "high"
}
```

### Update a bug

```
PUT /api/bugs/{id}
```

Example request body:

```json
{
  "status": "in-progress",
  "priority": "medium"
}
```

### Delete a bug

```
DELETE /api/bugs/{id}
```

## Key Concepts Demonstrated

* RESTful API design
* CRUD operations
* Entity Framework Core for database interaction
* Data validation and error handling
* Layered architecture using Models, DTOs, and Controllers
* API documentation with Swagger

## Future Improvements

* Add timestamps (CreatedAt, UpdatedAt)
* Add filtering (by status or priority)
* Implement authentication/authorization
* Add unit tests
* Use EF Core migrations for database versioning

## Author

Max Droge
GitHub: https://github.com/MaxDroge
