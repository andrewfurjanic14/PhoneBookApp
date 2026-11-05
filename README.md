# PhoneBookApp
PhoneBookApp is a .NET console application for managing a personal contact list. It combines a simple text-driven UI with a local database-backed data layer, making it easy to add, update, view, and manage contact records.
## Overview
This project is structured as a small multi-project .NET solution:
- `PhoneBookApp` — the main application, including the database context, contact model, business logic, and console screens
- `ConsoleUI` — reusable screen state and menu flow logic
- `RandomUserGenerator` — helper code used to generate sample contact data for testing and demos
The app stores contact information in SQL Server using Entity Framework Core and exposes a console-driven navigation flow for interacting with the records.
## Features
- Add a new contact
- Edit an existing contact
- Delete a contact
- View all saved contacts
- Search or browse contact records through the UI
- Seed sample contacts with generated data for testing
## Technology Stack
- C# / .NET 10
- Entity Framework Core
- SQL Server (LocalDB connection by default)
- Spectre.Console for terminal UI styling and prompts
## Project Structure
```text
PhoneBookApp/
├── Data/
│   ├── AppDbContext.cs
│   └── DTOs/
├── Migrations/
├── Models/
├── Services/
├── UI/
├── appsettings.json
├── Program.cs
├── PhoneBookApp.csproj
├── ...
ConsoleUI/
├── StateMachine/
├── ConsoleUI.csproj
RandomUserGenerator/
├── Datasets/
├── Models/
├── RandUserGen.cs
├── RandomUserGenerator.csproj
PhoneBookApp.slnx
```
## Prerequisites
Before running the project, make sure the following are installed:
- .NET 10 SDK
- SQL Server LocalDB or another SQL Server instance that matches the connection string
## Configuration
The database connection string is stored in:
```json
PhoneBookApp/appsettings.json
```
Default configuration:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\ProjectModels; Database=PhoneBookDb; Trusted_Connection=True; TrustServerCertificate=True;"
  }
}
```
If you are using a different SQL Server instance, update the connection string to match your environment.
## Getting Started
1. Restore dependencies:
```bash
dotnet restore
```
2. Build the solution:
```bash
dotnet build
```
3. Run the application:
```bash
dotnet run --project PhoneBookApp/PhoneBookApp.csproj
```
## Database Setup
The project uses Entity Framework Core migrations to manage the database schema. If the database does not yet exist, apply migrations with:
```bash
dotnet ef database update --project PhoneBookApp/PhoneBookApp.csproj
```
If `dotnet ef` is not available, install the EF Core CLI tools:
```bash
dotnet tool install --global dotnet-ef
```
## Usage
When the application starts, it launches the console menu system and allows you to navigate through contact management screens. The interface is text-based and intended to be used from a terminal or command prompt.
