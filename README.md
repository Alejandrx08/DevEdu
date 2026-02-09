![C#](https://img.shields.io/badge/C%23-.NET-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![Status](https://img.shields.io/badge/Status-Active-success)
![License](https://img.shields.io/badge/License-MIT-green)
![Version](https://img.shields.io/badge/Version-1.0-orange)

# DevEdu

**DevEdu** is a Windows Forms desktop application built in C# designed to teach software development through an intuitive, interactive, and visual learning environment.

Originally developed as a university project, DevEdu has evolved into a modular educational system that integrates programming practice, user management, and interactive learning tools.

---

## Overview

DevEdu provides a structured environment where students can learn programming concepts through visualization, exercises, and interactive modules. The project focuses on usability, modular design, and real database integration.

---

## Features

* User authentication system (Login / Register)
* Role-based user management
* Full CRUD operations with MySQL
* Educational modules for programming concepts
* Interactive exercises and quizzes
* DevBot (AI-assisted learning module)
* DevHub (social / interactive section)
* Modular architecture structure
* Real database persistence
* Multi-form UI navigation
* Session handling

---

## Architecture

The project follows a modular layered structure:

* **UI Layer** – Windows Forms (Interface & Interaction)
* **Infrastructure Layer** – Database & configuration
* **Core Logic** – Session, system behavior, and rules
* **Database** – MySQL persistence layer

---

## Technologies Used

* C# (.NET Framework / Windows Forms)
* MySQL
* ADO.NET
* Git / GitHub
* Visual Studio

---

## Project Structure

```
DevEdu/
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
├── Infrastructure/
│   └── DB/
│
├── Resources/
├── Session.cs
└── Program.cs
```

---

## Getting Started

### Requirements

* Windows OS
* Visual Studio
* MySQL Server
* .NET Framework compatible with project

### Setup

1. Clone the repository
2. Configure your MySQL connection in `DbConfig.cs`
3. Create the required database structure
4. Build and run the project

---

## Roadmap

* Improve architecture (Service Layer)
* Enhance DevHub with real-time interaction
* Improve UI consistency
* Add progress tracking system
* Expand educational modules
* Improve DevBot AI capabilities
* Add secure configuration management
* Add versioning & releases

---

## Status

Active development – evolving from university project to structured educational system.

---

## License

This project is licensed under the MIT License.

---

## Author

Developed by **Alejandro Ibarra**

---

## Contributing

Contributions, suggestions, and improvements are welcome.

---

## Future Vision

DevEdu aims to become a complete interactive learning platform focused on teaching software development through visualization, practice, and intelligent assistance.
