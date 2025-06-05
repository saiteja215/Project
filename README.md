# Ecommerce Backend

This project is a simplified sample of a real-time ecommerce backend built with **ASP.NET Core (.NET 8)** following a clean architecture style. It demonstrates JWT authentication, role-based authorization, basic CRUD for products, order placement with simulated payments, and real-time notifications via SignalR.

## Features
- User registration and login with JWT
- Admin and User roles
- CRUD APIs for products
- Order placement and status updates
- Real-time order notifications using SignalR
- In-memory EF Core database (can be swapped for PostgreSQL/SQL Server)
- Swagger UI for API exploration

## Project Structure
- `Controllers/` – public facing API controllers
- `AdminControllers/` – admin-only endpoints
- `DTOs/` – data transfer objects
- `Models/` – EF Core entities and `ApplicationDbContext`
- `Services/` – business logic services
- `Repositories/` – repository abstractions (simplified here)
- `Interfaces/` – service and repository contracts
- `Helpers/` – JWT generation, payment simulation and mapping profile
- `Hubs/` – SignalR hubs

## Running
This repository only contains code files without compiled binaries. To run locally you need the .NET 8 SDK:

```bash
cd EcommerceBackend
dotnet restore
dotnet run
```

Swagger UI will be available at `https://localhost:5001/swagger` by default.
