# Employee Management API

A layered ASP.NET Core Web API project built using Entity Framework Core and SQL Server.

This project demonstrates a clean backend architecture using Repository Pattern, Service Layer, DTOs, Validation, Logging, Pagination, Searching, and Sorting.

---

# Features

- Employee CRUD Operations
- Department CRUD Operations
- Layered Architecture (DAL / BLL / Utility)
- Repository Pattern
- DTO-Based API Structure
- FluentValidation
- Global Exception Middleware
- Serilog Logging
- Pagination
- Searching
- Sorting
- Standardized API Responses
- Swagger/OpenAPI Documentation
- SQL Server Integration
- Entity Framework Core Migrations

---

# Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- FluentValidation
- Serilog
- Swagger / OpenAPI

---

# Project Structure

```txt
EmployeeManagementSystem
│
├── EmployeeManagement
│   ├── Controllers
│   ├── Middleware
│
├── EmployeeManagement.BLL
│   ├── Services
│   ├── Interfaces
│   ├── Validators
│
├── EmployeeManagement.DAL
│   ├── Data
│   ├── Models
│   ├── DTOs
│   ├── Contracts
│   ├── Repositories
│
├── EmployeeManagement.Utility
│   ├── Responses
│   ├── Utility
```

---

# API Features

## Pagination

```http
GET /api/Employee?pageNumber=1&pageSize=5
```

## Searching

```http
GET /api/Employee/search?name=chi
```

## Sorting

```http
GET /api/Employee?sortBy=name
```

---

# Validation

Implemented using FluentValidation.

Example validations:
- Required fields
- Email format validation
- Salary validation
- Department validation

---

# Logging

Implemented using Serilog.

Logs are stored inside:

```txt
Logs/
```

---

# Setup Instructions

## Clone Repository

```bash
git clone https://github.com/Chintan-Patel-Games/employee-management-api.git
```

---

## Navigate To Project

```bash
cd employee-management-api
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Update Database

```bash
dotnet ef database update --project EmployeeManagement.DAL --startup-project EmployeeManagement
```

---

## Run Project

```bash
dotnet run --project EmployeeManagement
```

---

# Swagger

After running the project:

```txt
http://localhost:5038/swagger
```

---

# Architecture Used

- Repository Pattern
- Service Layer Pattern
- DTO Pattern
- Middleware-Based Exception Handling
- Standardized API Response Pattern

---

# Future Improvements

- JWT Authentication
- Role-Based Authorization
- Unit Testing
- AutoMapper
- Redis Caching

---

# Author

Chintan Patel
