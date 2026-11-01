![C#](https://img.shields.io/badge/C%23-.NET%208-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)

# DevEdu

**DevEdu** is a Windows Forms desktop application developed in C# for a university project. It includes user authentication and registration, user administration, student and teacher management, password recovery, an activity log, and educational screens with exercises and explanations.

The project separates interface code from application operations through presenters, services, validation classes, and data-access helpers. The MVP pattern is used in the areas where view interfaces and presenters are defined.

## Features

### Authentication and user management

- User registration and login.
- BCrypt password-hash verification during authentication.
- Password recovery using a time-limited verification code sent by email.
- User and account information used by the application's session and menu flows.
- Offline queuing of registration operations when a recognized SQL Server connectivity failure occurs.

### Administration

- Student and teacher management.
- General user management.
- Create, read, update, and delete operations for the supported entities.
- Activity log (`Bitacora`) retrieval.

### Educational screens

The repository includes Windows Forms for the following areas:

- **DevBot** — chat interface.
- **DevHub** — module menu.
- **DevTrivia** — quizzes, explanations, and easy, medium, and difficult exercise screens.
- **DevVis** — visualization exercises, including loops and data structures.
- **DevEx** — exercises and explanatory content.

This list reflects screens present in the repository; it does not imply that every module includes a complete course or a broad set of exercises.

### Data storage

- Microsoft SQL Server for central application data.
- SQLite for the local queue of pending registration operations.
- ADO.NET through `Microsoft.Data.SqlClient` for SQL Server access.
- `Microsoft.Data.Sqlite` for the local operation queue.
- Parameterized SQL commands in the reviewed data-access and service code.

---

## Architecture

DevEdu uses separation of responsibilities and applies **Model–View–Presenter (MVP)** where appropriate.

```text
Windows Forms Views
        ↓
    Presenters
        ↓
     Services
        ↓
Data-access helpers ─────→ SQL Server
        │
        └───────────────→ SQLite offline queue
```

### Main code areas

| Area | Responsibility |
|---|---|
| `Views/` | Windows Forms screens and user interaction. |
| `Core/Presenters/` | Coordinates view events and application actions for views that use MVP. |
| `Core/Interfaces/` | Contracts implemented by presenter-driven views. |
| `Core/Services/` | Authentication, registration, password recovery, student/teacher operations, activity log, and database connection logic. |
| `Core/Services/query/` | Reusable `SELECT`, `INSERT`, `UPDATE`, and `DELETE` helpers. |
| `Core/Models/` and `Core/DTOs/` | Application models and data-transfer objects. |
| `Core/Validations/` | Login and user-input validation. |
| `Core/Services/SQLite/` | Local operation queue and background synchronization components. |
| `Resources/DB_SCHEMA/` | SQL Server database setup script. |

Not every form necessarily follows MVP; the pattern is used where the corresponding interfaces and presenters exist.

---

## Offline registration and synchronization

DevEdu includes a local queue for registration operations that cannot be sent to SQL Server because of a recognized connectivity failure.

### Flow

1. The registration service attempts to register the user in SQL Server.
2. When the handled SQL Server connectivity failure occurs, the registration operation is placed in a local SQLite queue.
3. The queued payload is protected with Windows DPAPI through `ProtectedData`, using the current Windows user context.
4. `SQLiteSyncWorker` runs in the background and checks for synchronization work every 30 seconds.
5. `SQLiteSyncService` coordinates processing, and `SQLiteRegistrationRepository` applies queued registrations to SQL Server.
6. SQL Server's `dbo.operaciones_sincronizadas` table records processed operation IDs to support idempotent processing.
7. Synchronization errors are written to a local log. The logger records the operation and exception type, not the exception message or queued registration payload.

Duplicate-email and other processing conflicts are handled by the synchronization flow; this is not the same as a dedicated user-facing conflict-resolution screen.

### Local runtime files

The code builds these paths beneath `%LOCALAPPDATA%\DevEdu`:

| Purpose | Location |
|---|---|
| SQLite operation queue | `%LOCALAPPDATA%\DevEdu\Offline\devedu-sync.db` |
| Synchronization log | `%LOCALAPPDATA%\DevEdu\Logs\offline-sync.log` |

These are runtime files, not source files. Do not commit local databases or logs to version control.

**Important:** SQLite is only the local queue for pending operations; SQL Server remains the central database.

---

## Technologies

- C#
- .NET 8 (`net8.0-windows`)
- Windows Forms
- Microsoft SQL Server
- ADO.NET and `Microsoft.Data.SqlClient`
- SQLite and `Microsoft.Data.Sqlite`
- BCrypt.Net-Next for password hashing and verification
- Windows DPAPI through `System.Security.Cryptography.ProtectedData`
- Newtonsoft.Json
- Microsoft.Extensions.Configuration packages
- Visual Studio 2022
- Git

The project file targets .NET 8 for Windows and enables Windows Forms. Use a Windows environment to build and run the application.

---

## Project structure

Simplified structure based on the repository:

```text
DevEdu/
├── DevEdu.sln
├── README.md
├── DevEdu/
│   └── DevEdu/
│       ├── Core/
│       │   ├── DTOs/
│       │   ├── Interfaces/
│       │   ├── Models/
│       │   ├── Presenters/
│       │   ├── Services/
│       │   │   ├── query/
│       │   │   └── SQLite/
│       │   └── Validations/
│       ├── Resources/
│       │   └── DB_SCHEMA/
│       │       └── devedu_databse.sql
│       ├── Views/
│       │   ├── Admin/
│       │   ├── Auth/
│       │   ├── DevBot/
│       │   ├── DevEx/
│       │   ├── DevHub/
│       │   ├── DevTrivia/
│       │   ├── DevVis/
│       │   └── Main/
│       ├── App.config
│       ├── DevEdu.csproj
│       └── Program.cs
└── .gitignore
```

The SQL script's filename is currently `devedu_databse.sql` (including that spelling); use the existing filename unless you rename it in the repository.

---

## Database setup

1. Install or make available a compatible Microsoft SQL Server instance.
2. Open `DevEdu/DevEdu/Resources/DB_SCHEMA/devedu_databse.sql` in SQL Server Management Studio or another SQL client.
3. Execute the script. It creates the `devedu` database if it does not exist and defines the application's tables, including users, courses, students, teachers, course relationships, classes, assignments, progress, activity logging, synchronization records, and password-recovery codes.
4. Configure the connection settings required by the application for your SQL Server environment.
5. Open `DevEdu.sln` in Visual Studio 2022.
6. Restore NuGet packages, build the solution, and run the application on Windows.

The password-recovery service also expects the `dbo.password_recovery_codes` table provided by the SQL schema. The offline synchronization flow expects `dbo.operaciones_sincronizadas`.

Do not put real credentials, passwords, API keys, or email-account secrets in source control. Verify any required configuration values for your environment before running the application.

---

## Security and development notes

- Authentication verifies passwords against BCrypt hashes.
- Use parameterized SQL commands rather than concatenating user input into queries.
- DPAPI-protected queue payloads are tied to the Windows user context and are not intended to be moved between Windows profiles.
- The synchronization logger omits exception messages and registration payloads.
- Keep local runtime data, credentials, and secrets out of version control.
- The repository snapshot does not establish that a formal automated test suite exists; test coverage should not be inferred from manual checks or the presence of application code.

---

## Getting started

1. Clone the repository.
2. Open `DevEdu.sln` in Visual Studio 2022 on Windows.
3. Configure the SQL Server connection settings for your environment.
4. Execute `DevEdu/DevEdu/Resources/DB_SCHEMA/devedu_databse.sql`.
5. Restore NuGet packages.
6. Build and run the application.

## License

The repository snapshot includes no `LICENSE` file. Add one if you intend to distribute DevEdu under a specific license. A badge alone does not establish the applicable license terms.
