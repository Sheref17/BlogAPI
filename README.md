# 📝 Blog API — Clean Architecture + DDD + CQRS

A RESTful Blog API built with ASP.NET Core using **Clean Architecture**, **Domain-Driven Design (DDD)**, and **CQRS**.
This project demonstrates a scalable and maintainable backend with clear separation of concerns.

---

## 🚀 Features

* 🔐 JWT Authentication & Role-based Authorization
* 📝 Blog Posts (Create / Update / Delete / Get)
* 💬 Comments System (Create / Update / Delete)
* 🏷️ Categories & Tags
* ❗ Global Exception Handling Middleware
* ⚡ CQRS (Command & Query separation)

---

## 🧠 Architecture & Design

### 🔹 Domain-Driven Design (DDD)

* The **CoreLayer (Domain)** contains:

  * Entities: `BlogPost`, `Comment`, `Category`, `Tag`
  * Business logic inside entities (not controllers)
* The domain layer is completely independent

---

### 🔹 Clean Architecture

The project is structured into layers:

```plaintext
CoreLayer          → Domain (Entities, Enums)
ApplicationLayer   → CQRS, DTOs, Interfaces
InfrastructureLayer → EF Core, Identity, Repositories, Services
PresantisonLayer   → Controllers (Web API)
```

* No direct dependency from Application → Infrastructure
* Each layer has a single responsibility

---

### 🔹 CQRS (Command Query Responsibility Segregation)

* **Commands (Write operations)** → handled via repositories
* **Queries (Read operations)** → handled via query services with DTO projection
* Full separation between read and write models

---

## 🧰 Tech Stack

* .NET 8 / ASP.NET Core
* Entity Framework Core
* ASP.NET Identity
* MediatR
* SQL Server

---

## 🔑 Authentication

* JWT-based authentication
* Role-based authorization (Admin / User)
* Secured endpoints using `[Authorize]`

---

## 📌 API Endpoints (Examples)

### 🔐 Auth

* `POST /api/auth/register`
* `POST /api/auth/login`

### 📝 Blog

* `GET /api/blog`
* `GET /api/blog/{id}`
* `POST /api/blog`
* `PUT /api/blog/{id}`
* `DELETE /api/blog/{id}`

### 💬 Comments

* `POST /api/comments`
* `PUT /api/comments/{id}`
* `DELETE /api/comments/{id}`

---

## ⚙️ How to Run

```bash
git clone https://github.com/Sheref17/BlogAPI.git
cd BlogAPI
```

1. Update the connection string in `appsettings.json`
2. Apply migrations:

```bash
dotnet ef database update
```

3. Run the project:

```bash
dotnet run
```

---

## 📊 Highlights

* ✔️ Business logic inside the domain (DDD approach)
* ✔️ No entity leakage (DTOs used for responses)
* ✔️ Optimized queries using projection (no unnecessary Includes)
* ✔️ Clear separation of concerns
* ✔️ Scalable and maintainable architecture

---

## 🔮 Future Improvements

* 📄 Pagination
* 🔍 Search & Filtering
* 📊 Logging (Serilog)
* ⚡ Caching
* 📘 Swagger enhancements

---

## 👨‍💻 Author

**Sherif**
GitHub: https://github.com/Sheref17

---

⭐ This project is built to demonstrate backend best practices using Clean Architecture, DDD, and CQRS.
