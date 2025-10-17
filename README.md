This project provide backend service for the blog application, including database operations, and ODATA 

Prerequisites
- Make sure you have the following installed:
- .NET 9
- Entity Framework Core Tools
- A database server (e.g. SQL Server / MySQL)
- Docker for containerized setup

Configuration
- Open the following files in the project:
- appsettings.json
- appsettings.Development.json
- Locate the ConnectionStrings section and set your database connection:

Database Setup
- dotnet ef migrations add InitialCreate
- dotnet ef database update

Running the Project
 - dotnet watch run

Testing API format example
- http://localhost:8080/v1/Blogs

