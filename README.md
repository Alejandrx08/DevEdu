![C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.7.2-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![Status](https://img.shields.io/badge/Status-Active-success)
![License](https://img.shields.io/badge/License-MIT-green)
![Version](https://img.shields.io/badge/Version-v0.3.0-orange)

# DevEdu

**DevEdu** is a Windows Forms desktop application developed in C# that aims to teach software development through an intuitive, interactive, and visual learning environment.

Originally created as a university project, DevEdu has evolved into a modular educational platform that integrates user management, programming practice, learning modules, and database-driven functionality.

---

## Overview

DevEdu provides a structured environment where students can learn programming concepts through visualization, exercises, interactive modules, and educational tools.

The project focuses on modular architecture, scalability, usability, and the application of real-world software engineering practices.

---

## Features

### Authentication & Users

- User registration
- Login system
- Role-based access control
- Session management

### Administration

- Student management
- Teacher management
- User administration
- CRUD operations

### Educational Modules

- DevBot
- DevHub
- DevTrivia
- DevVis
- DevEx
- Learning content visualization

### Database Integration

- SQL Server integration
- Database abstraction layer
- Centralized CRUD operations
- Service-oriented business logic
- Secure connection management using configuration files

---

## Architecture

The project follows a modular layered architecture based on the **Separation of Concerns (SoC)** principle.

The architecture separates responsibilities between the user interface, validation logic, business services, models, and database access.

### Architectural Principles

- Separation of Concerns
- Database Abstraction
- Business Logic Separation
- Validation Layer
- Modular Design
- Reusable Components
- Session-Based State Management

### Data Access Layer

DevEdu implements a dedicated database access layer composed of:

- `DatabaseConnection`
- `SELECT`
- `INSERT`
- `UPDATE`
- `DELETE`

This layer centralizes database connection management and common data operations, promoting code reuse and reducing duplication throughout the application.

### Business Logic Layer

DevEdu separates business rules and validation from the user interface through dedicated services and validators.

#### Validators

Located in `Core/Validations/`, validators contain pure validation rules such as:

- Empty field validation
- Email format validation
- Password length validation
- Input validation

Validators do not directly access the database.

#### Services

Located in `Core/Services/`, services orchestrate business operations and communicate with the data access layer when necessary.

Examples include:

- `UsuarioService`
- `AuthService`

These services handle operations related to user management, authentication, and business rules.

This architecture ensures that the Windows Forms layer remains focused on user interface events while validation, business logic, and persistence operations are delegated to their corresponding layers.

---

## Technologies Used

- C# (.NET Framework 4.7.2)
- Windows Forms
- Microsoft SQL Server 2022
- Microsoft.Data.SqlClient
- ADO.NET
- Git
- GitHub
- Visual Studio 2022

---

## Project Structure

```text
DevEdu/
│
├── Core/
│   │
│   ├── Models/
│   │   ├── Persona.cs
│   │   └── UsuarioAutenticado.cs
│   │
│   ├── Services/
│   │   ├── DatabaseConnection.cs
│   │   ├── AuthService.cs
│   │   ├── UsuarioService.cs
│   │   │
│   │   └── query/
│   │       ├── SELECT.cs
│   │       ├── INSERT.cs
│   │       ├── UPDATE.cs
│   │       └── DELETE.cs
│   │
│   └── Validations/
│       ├── LoginValidator.cs
│       └── UsuarioValidator.cs
│
├── UI/
│   │
│   └── Forms/
│       ├── Auth/
│       ├── Admin/
│       ├── DevBot/
│       ├── DevHub/
│       ├── DevEx/
│       ├── DevTrivia/
│       ├── DevVis/
│       └── Main/
│
├── appsettings.json
├── Program.cs
└── DevEdu.csproj
