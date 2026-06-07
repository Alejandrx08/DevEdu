![C#](https://img.shields.io/badge/C%23-.NET-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![Status](https://img.shields.io/badge/Status-Active-success)
![License](https://img.shields.io/badge/License-MIT-green)
![Version](https://img.shields.io/badge/Version-v0.2.0-orange)

# DevEdu

**DevEdu** is a Windows Forms desktop application developed in C# that aims to teach software development through an intuitive, interactive, and visual learning environment.

Originally created as a university project, DevEdu has evolved into a modular educational platform that integrates user management, programming practice, learning modules, and database-driven functionality.

---

## Overview

DevEdu provides a structured environment where students can learn programming concepts through visualization, exercises, interactive modules, and educational tools.

The project focuses on modular architecture, scalability, usability, and real-world software engineering practices.

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
- Full CRUD operations

### Educational Modules
- DevBot (AI-assisted learning)
- DevHub (interactive community module)
- DevTrivia
- DevVis
- DevEx
- Learning content visualization

### Database Integration
- SQL Server integration
- Database abstraction layer
- CRUD service architecture
- Secure connection management using configuration files

---

## Architecture

The project follows a modular layered architecture based on Separation of Concerns (SoC).

### Architectural Principles

- Separation of Concerns
- Database Abstraction
- Service-Oriented Data Access
- Modular Design
- Reusable Components
- Session-Based State Management

### Data Access Layer

DevEdu implements a dedicated database access layer composed of:

- DatabaseConnection
- SELECT Service
- INSERT Service
- UPDATE Service
- DELETE Service

This architecture centralizes connection management and promotes code reuse while reducing duplication throughout the application.

---

## Technologies Used

- C# (.NET 8)
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
│   ├── Services/
│   │   ├── DatabaseConnection.cs
│   │   └── query/
│   │       ├── SELECT.cs
│   │       ├── INSERT.cs
│   │       ├── UPDATE.cs
│   │       └── DELETE.cs
│
├── UI/
│   ├── Forms/
│   │   ├── Auth/
│   │   ├── Admin/
│   │   ├── DevBot/
│   │   ├── DevHub/
│   │   ├── DevEx/
│   │   ├── DevTrivia/
│   │   ├── DevVis/
│   │   └── Main/
│
├── appsettings.json
├── Program.cs
└── DevEdu.csproj
```

---

## Database

The application uses Microsoft SQL Server as its primary database management system.

### Main Entities

- Users
- Students
- Teachers
- Courses
- Classes
- Tasks
- Student-Course Relationships
- Teacher-Course Relationships
- Learning Progress

### Features

- Relational database model
- Foreign key relationships
- Normalized structure
- Real-time persistence
- Query abstraction layer

---

## Getting Started

### Requirements

- Windows 10/11
- Visual Studio 2022
- .NET 8 SDK
- SQL Server 2022
- SQL Server Management Studio (SSMS)

### Installation

1. Clone the repository

```bash
git clone https://github.com/Alejandrx08/DevEdu.git
```

2. Open the solution in Visual Studio.

3. Create an `appsettings.json` file.

4. Configure your SQL Server connection string.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DevEdu;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

5. Execute the database creation script.

6. Build and run the application.

---

## Roadmap

### Short Term

- Improve DevHub functionality
- Expand educational modules
- Improve UI consistency
- Add advanced search features

### Medium Term

- Stored Procedures
- Reporting System
- Progress Analytics
- User Activity Tracking

### Long Term

- AI-powered tutoring improvements
- API Integration
- Cloud Synchronization
- Mobile Companion Application

---

## Current Status

Active Development

DevEdu is currently under active development and continues to evolve from an academic project into a complete educational software platform.

---

## Contributing

Contributions, ideas, and improvements are welcome.

Feel free to fork the repository and submit pull requests.

---

## License

This project is licensed under the MIT License.

---

## Author

**Alejandro Ibarra**

GitHub:
https://github.com/Alejandrx08

---

## Future Vision

DevEdu aims to become a complete educational ecosystem focused on teaching software development through visualization, interaction, practice, and intelligent assistance.
