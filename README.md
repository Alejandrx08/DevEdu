
![C#](https://img.shields.io/badge/C%23-.NET%208-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![Status](https://img.shields.io/badge/Status-Active-success)
![License](https://img.shields.io/badge/License-MIT-green)
![Version](https://img.shields.io/badge/Version-v0.3.0-orange)

# DevEdu

**DevEdu** is a Windows Forms desktop application developed in C# as a university project. It provides an interactive environment for learning software development through educational modules, exercises, and visual learning tools.

The project uses a modular architecture to separate user interface responsibilities, validation, business logic, and data access.

---

## Overview

DevEdu brings together user management, authentication, administration, and educational modules in a desktop application. The project emphasizes separation of responsibilities, reusable components, and maintainable code.

## Features

### Authentication and User Management

- User registration and login.
- Session management and role-based access where implemented.
- Offline user registration when a recognized SQL Server connectivity failure prevents registration.
- Automatic background synchronization of queued registrations when SQL Server becomes available again.
- Duplicate-email conflict detection during synchronization.

### Administration

- Student and teacher management.
- User administration.
- CRUD operations for supported entities.

### Educational Modules

- DevBot
- DevHub
- DevTrivia
- DevVis
- DevEx
- Educational content and visualization tools.

### Database Integration

- Microsoft SQL Server 2022 for central application data.
- SQLite for the local queue of pending offline registration operations.
- ADO.NET and `Microsoft.Data.SqlClient`.
- Parameterized SQL commands.
- Reusable data-access components.

---

## Offline Registration and Synchronization

DevEdu supports queuing registration operations locally when a recognized SQL Server connectivity failure prevents registration.

### How It Works

1. The registration service attempts to register the user in SQL Server.
2. If a recognized SQL connectivity failure occurs, the registration operation is saved in a local SQLite database.
3. The queued payload is protected using Windows Data Protection API (DPAPI) for the current Windows user.
4. A background worker checks for pending operations every 30 seconds.
5. When SQL Server becomes available, the synchronization service processes pending registrations.
6. Successful operations are marked as completed. Duplicate email addresses and operation-type mismatches are recorded as conflicts.
7. Synchronization errors are written to a local log without including exception messages or registration payloads.

### Local Runtime Files

The module stores local data under `%LOCALAPPDATA%\DevEdu`.

| Purpose | Location |
|---|---|
| SQLite operation queue | `%LOCALAPPDATA%\DevEdu\Offline\devedu-sync.db` |
| Synchronization log | `%LOCALAPPDATA%\DevEdu\Logs\offline-sync.log` |

The SQL Server database includes the `dbo.operaciones_sincronizadas` table to track processed operation IDs and support idempotent synchronization.

**Important:** SQLite is used as a local queue for offline registration. It does not replace SQL Server as the central database. The local SQLite database and log are runtime files and should not be committed to the repository.

---

## Architecture

DevEdu follows a modular architecture based on **Separation of Concerns (SoC)**. The **Model–View–Presenter (MVP)** pattern is used where appropriate to separate user interface events from application logic.

The main responsibility flow is:

```text
View → Presenter → Services → Data Access → SQL Server
                         ↘ SQLite offline queue
```

### Main Layers

- **Views:** Windows Forms screens and user interaction.
- **Presenters:** coordinate view events and application actions where MVP is used.
- **Services:** coordinate operations such as registration, authentication, and synchronization.
- **Validation:** contains input-validation rules independently of database access.
- **Data Access:** handles database communication and common SQL operations.
- **Offline Queue:** stores pending registration operations locally until synchronization is possible.

### Data Access

The data-access layer includes reusable components for common database operations, such as:

- `DatabaseConnection`
- `SELECT`
- `INSERT`
- `UPDATE`
- `DELETE`

The offline registration repository applies queued operations to SQL Server and records their processing status.

### Offline Synchronization Components

- `OfflineOperationQueue`: manages pending operations in SQLite.
- `OfflineRegistrationRepository`: applies queued registrations to SQL Server.
- `OfflineSyncService`: coordinates the synchronization process.
- `OfflineSyncWorker`: runs periodic synchronization.
- `OfflineSyncLogger`: records synchronization errors.

---

## Technologies

- C#
- .NET 8
- Windows Forms
- Microsoft SQL Server 2022
- SQLite
- ADO.NET
- `Microsoft.Data.SqlClient`
- BCrypt for password hashing
- Windows DPAPI for protecting locally queued payloads
- Visual Studio 2022
- Git and GitHub

---

## Project Structure

The following is a simplified overview of the project structure. Additional files and folders may exist in the repository.

```text
DevEdu/
├── Core/
│   ├── Models/
│   ├── Presenters/
│   ├── Services/
│   │   ├── query/
│   │   └── Offline/
│   │       ├── OfflineOperationQueue.cs
│   │       ├── OfflineRegistrationRepository.cs
│   │       ├── OfflineSyncService.cs
│   │       ├── OfflineSyncWorker.cs
│   │       └── OfflineSyncLogger.cs
│   └── Validation/
├── Resources/
│   ├── DB_SCHEMA/
│   │   └── devedu_database.sql
│   ├── ico/
│   │   └── DevEdu Blue.ico
├── UI/
│   └── Forms/
├── Properties/
│   └── Resources.resx
├── Program.cs
└── DevEdu.csproj
```

---

## Database Setup

1. Ensure that Microsoft SQL Server 2022 is installed or accessible.
2. Open `Resources/DB_SCHEMA/devedu_database.sql` in SQL Server Management Studio or another compatible SQL client.
3. Execute the script against the intended development database.
4. Configure the application's connection settings for your local SQL Server instance.
5. Restore NuGet packages and build the solution in Visual Studio 2022.
6. Run the application on Windows.

The database script includes `dbo.operaciones_sincronizadas`, which is required by the offline registration synchronization module.

**Security note:** do not commit real database credentials, passwords, API keys, or other secrets.

---

## Manual Verification of Offline Synchronization

The following scenarios have been manually verified during development:

- The application starts while SQL Server is unavailable.
- Registration operations can be queued locally in SQLite.
- Pending registrations synchronize after SQL Server becomes available again.
- The background worker periodically checks for pending operations.
- A registration using an email that already exists is marked as a conflict.
- Passwords are stored as BCrypt hashes rather than plain text.
- Synchronization errors are recorded in `offline-sync.log`.

These are manual development checks and do not imply that a formal automated test suite exists.

---

## Security and Development Notes

- Keep database credentials and secrets out of source control.
- Do not commit local SQLite databases, log files, or other user-specific runtime data.
- Use parameterized SQL commands instead of concatenating user input into queries.
- DPAPI protection is tied to the Windows user context; queued payloads are not intended to be transferred between Windows user profiles.
- Synchronization conflicts are recorded for review. A dedicated conflict-resolution interface can be considered if required by the project scope.

---

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio 2022.
3. Configure the SQL Server connection settings for your environment.
4. Execute `Resources/DB_SCHEMA/devedu_database.sql`.
5. Restore NuGet packages.
6. Build and run DevEdu on Windows.

---

## License

This repository displays an MIT License badge. Ensure that a `LICENSE` file containing the corresponding terms exists in the repository before distributing the project under that license.
