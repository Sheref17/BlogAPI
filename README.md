# BlogAPI 🚀

A scalable **ASP.NET Core Web API** for a full-featured blogging platform built with **Clean Architecture + CQRS + MediatR**.

This project includes authentication, role-based authorization, post management, categories, comments, tags, pagination, search, filtering, validation, and global exception handling.

---

# 📌 Features

## 🔐 Authentication & Authorization

* User Registration
* User Login with JWT
* Role-based Authorization:

  * **Admin**
  * **Editor**
  * **User**

---

## 📝 Blog Posts

* Create Post (**Admin / Editor**)
* Update Post (**Admin / Editor**)
* Delete Post (**Admin only**)
* Get All Posts
* Get Post Details
* Change Post Status:

  * Draft
  * Published
  * Archived

---

## 📂 Categories

* Create Category
* Update Category
* Delete Category

---

## 💬 Comments

* Add Comment (All authenticated users)
* Update Comment (Comment owner)
* Delete Comment (Comment owner / Admin)
* Paginated comments inside post details

---

## 🏷️ Tags

* Create Tag
* Update Tag
* Delete Tag

---

# 🔎 Search & Filtering

Users can:

* Search posts by title
* Filter by category
* Filter by tag

Admins / Editors can:

* Filter posts by status (Draft / Published / Archived)

---

# 📄 Pagination

Implemented for:

* Posts
* Comments

### Default:

```plaintext id="pagination_default"
Page = 1
PageSize = 5
```

---

# 🛡️ Validation

Implemented using:

## FluentValidation + MediatR Pipeline Behavior

### Includes:

* Create / Update / Delete validation
* Query validation
* Automatic request validation before handlers

---

# ⚠️ Global Exception Handling

Custom middleware handles:

* ValidationException → 400
* NotFoundException → 404
* ForbiddenException → 403
* ConflictException → 409
* InternalServerError → 500

---

# 🧱 Project Architecture

```plaintext id="architecture_tree"
BlogSystemSolution
│
├── CoreLayer
│   ├── Entities
│   ├── Enums
│   └── Interfaces
│
├── ApplicationLayer
│   ├── CQRS
│   ├── Validators
│   ├── Behaviors
│   ├── CustomExceptions
│   └── DependencyInjection
│
├── InfrastructureLayer
│   ├── DbContext
│   ├── Identity
│   ├── Repositories
│   ├── Services
│   └── DependencyInjection
│
└── PresentationLayer (API)
    ├── Controllers
    ├── Middlewares
    └── Extensions
```

---

# 🛠️ Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* JWT Authentication
* MediatR
* FluentValidation
* Swagger / OpenAPI

---

# 🚀 Getting Started

## 1️⃣ Clone the repository

```bash id="clone_command"
git clone https://github.com/Sheref17/BlogAPI.git
cd BlogAPI
```

---

## 2️⃣ Update connection string

Inside:

```plaintext id="appsettings_location"
appsettings.json
```

```json id="connection_string_block"
"ConnectionStrings": {
  "DefaultConnection": "Your_SQL_Server_Connection"
}
```

---

## 3️⃣ Apply migrations

```bash id="migration_command"
dotnet ef database update
```

---

## 4️⃣ Run project

```bash id="run_command"
dotnet run
```

---

# 👤 Seeded Default Accounts

## Admin:

```plaintext id="admin_seed_info"
Email: admin@blog.com
Password: Admin@123
```

---

## Editor:

```plaintext id="editor_seed_info"
Email: editor@blog.com
Password: Editor@123
```

---

# 📬 API Documentation

Swagger UI:

```plaintext id="swagger_path"
https://localhost:{port}/swagger
```

---

# 🔥 Security Rules

## User:

* View published posts only
* Add comments

---

## Editor:

* Create posts
* Update posts

---

## Admin:

* Full post control (Create / Update / Delete)
* Manage post status
* Advanced filtering

---

# 📈 Current Project Status

## ✅ Completed:

* Clean Architecture
* CQRS
* JWT Auth
* Role Authorization
* Pagination
* Search & Filtering
* FluentValidation
* Global Exception Middleware

---

# 🛣️ Future Improvements

* Serilog Logging
* Unit Testing
* Docker Support
* CI/CD
* Soft Delete
* Response Wrapper

---

# 👨‍💻 Author

**Sherif**

---

# ⭐ Final Note

This project was built to simulate a production-style backend system with scalable architecture and maintainable code practices.
