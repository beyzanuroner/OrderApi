# OrderApi

A clean ASP.NET Core Web API project demonstrating layered architecture, centralized error handling and RESTful design principles.

## 🚀 Technologies

- ASP.NET Core (.NET 10)
- C#
- Swagger / OpenAPI
- Dependency Injection
- Global Exception Middleware

## 🏗 Architecture Overview

This project follows a simplified layered structure:

- Controllers → Handle HTTP requests
- Services → Business logic layer
- DTOs → Request/Response separation
- Middleware → Centralized exception handling
- Custom Exceptions → Clean status code mapping

## 🔥 Features

- Clean Controller-Service separation
- Custom `ErrorResponse` format
- Global exception handling (400, 404, 500)
- Model validation override
- REST-compliant status codes
- In-memory data store (for demo purposes)

## 📌 Status Code Handling

| Scenario | Status Code |
|----------|------------|
| Validation error | 400 Bad Request |
| Resource not found | 404 Not Found |
| Unexpected error | 500 Internal Server Error |

## 🧪 How to Run

```bash
dotnet run
```

Swagger UI will be available at:

```
http://localhost:{port}/swagger
```

## 🎯 Purpose

This project was built as a backend fundamentals exercise to practice:

- API design
- Layered architecture
- Error handling discipline
- Clean code structure

---

Built for learning and backend development practice.