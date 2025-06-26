# 🎓 StudentManagementSystem.API

A backend Student Management System built using **ASP.NET Core**, following **Clean Architecture** principles with **CQRS**, **MediatR**, and **Entity Framework Core**.

---

## 🚀 Features

- 🔐 **Authentication & Authorization** with JWT and ASP.NET Identity
- 🧱 **Clean Architecture** (Domain, Application, Infrastructure, API layers)
- 📨 **CQRS pattern** using MediatR for clear separation of concerns
- 💾 **EF Core Integration** for data persistence
- 🧪 Easily testable structure with separation of logic and infrastructure
- ✅ Global exception handling for consistent error responses
- 📦 Follows SOLID principles and layered design for scalability

---

## 🗂️ Tech Stack

| Layer           | Technology                         |
|----------------|-------------------------------------|
| Presentation    | ASP.NET Core Web API               |
| Application     | MediatR, FluentValidation           |
| Domain          | Business Entities & Interfaces     |
| Infrastructure  | Entity Framework Core, SQL Server  |
| Auth            | ASP.NET Identity, JWT              |

---

## 🧠 Architecture Overview

StudentManagementSystem.API
│
├── Domain
│ └── Entities, Interfaces, ValueObjects
│
├── Application
│ └── Commands, Queries, Handlers (CQRS via MediatR)
│
├── Infrastructure
│ └── EF Core, Identity, Persistence
│
└── API
└── Controllers, Middleware, DI, Program.cs


---

## 🔑 Authentication Flow

- Register/Login endpoints issue **JWT tokens**
- Roles and claims are included in the token payload
- Protected endpoints use `[Authorize(Roles = "Admin")]` or similar attributes

---

## 📦 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/JaredKishCodes/StudentManagementSystem.API.git
Configure your database in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Your-SQL-Server-Connection-String-Here"
}
Apply EF Core migrations

dotnet ef database update
Run the API
dotnet run

📄 Sample Endpoints
Method	Route	Description
POST	/api/auth/register	Register a new user
POST	/api/auth/login	Login & receive JWT
GET	/api/students	Get all students (secured)
POST	/api/students	Create a new student
PUT	/api/students/{id}	Update student info
DELETE	/api/students/{id}	Delete a student

📚 Future Improvements (Optional Ideas)
📊 Add pagination and filtering

🧪 Unit and integration tests

📋 Swagger/OpenAPI docs

🌍 Multi-tenant or multi-school support

🧑‍🏫 Role-based dashboards

🧑‍💻 Author
Jared Kish Missiona
📍 .NET Backend Developer
🌐 Philippines | Available for remote roles
🔗 GitHub

📌 License
This project is open source and available under the MIT License.

---
