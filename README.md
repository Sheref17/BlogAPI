# 📝 Blog API

A clean and scalable **ASP.NET Core Web API** built using **Clean Architecture, CQRS, and DDD principles**.

---

## 🚀 Features

### 🔐 Authentication

* JWT-based authentication
* User registration & login

---

### 📰 Blog Management

* Create blog posts
* Update blog posts
* Delete blog posts
* Assign category to posts

---

### 💬 Comments

* Add comments to posts
* Retrieve comments per post
* Includes user info (username)


---

### 🗂 Categories

* Full CRUD operations
* Validation & existence checks

---

### ⚡ Pagination (NEW 🔥)

Pagination has been implemented for:

* ✅ Posts
* ✅ Comments (including inside Post Details)

#### ✨ Features:

* Default values:

  * `page = 1`
  * `pageSize = 5`
* Max page size limit = **5**
* Validation for invalid inputs
* Prevents large data loading
* Includes metadata:

```json id="2g6z7h"
{
  "data": [...],
  "page": 1,
  "pageSize": 5,
  "totalCount": 20,
  "totalPages": 4
}
```

---

## 🧱 Architecture

The project follows **Clean Architecture**:

```id="1r5m1z"
- CoreLayer (Domain)
- ApplicationLayer (CQRS + Interfaces)
- InfrastructureLayer (EF Core, Repositories)
- PersistenceLayer (Services)
- PresentationLayer (API Controllers)
```

---

## ⚙️ Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* MediatR (CQRS)
* SQL Server
* ASP.NET Identity
* JWT Authentication

---

## 📌 Best Practices Applied

* Separation of Concerns
* CQRS pattern (Command / Query split)
* DTO mapping
* Query optimization (no unnecessary loading)
* Pagination in DB (Skip / Take)
* Clean dependency flow

---



## 📈 Next Improvements

* 🔐 Role-based Authorization (Admin / Editor)
* 🟡 Post Status Management (Draft / Published)
* 🔍 Filtering & Search
* ✅ FluentValidation
* 🧾 Logging (Serilog)
* 🧪 Unit Testing

---

## 💡 Notes

* Pagination is handled efficiently at the database level
* Query layer optimized to avoid N+1 problems
* Clean Architecture boundaries are respected

---

## 👨‍💻 Author

Developed by **Sheref**

---
