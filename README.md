# TeacherDesk

> A desktop application for teachers to organize their courses, sequences, lessons, and exercises — all in one place.

![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux-blue)
![.NET](https://img.shields.io/badge/.NET-8-512BD4)
![Status](https://img.shields.io/badge/status-early%20development-orange)

---

## What is TeacherDesk?

TeacherDesk is a desktop tool designed for teachers who want to structure their pedagogical content without relying on cloud services, subscriptions, or unwieldy spreadsheets.

It lets you organize your work around a clear hierarchy:

```
Course → Sequence → Lesson → Exercise
```

Everything is stored locally on your machine. Your data stays yours.

---

## Features

### Available now
- Local data persistence (JSON)
- Basic Avalonia UI with navigation between views

### In progress
- Full CRUD for courses, sequences, lessons, and exercises
- Structured content editor per lesson

### Planned
- SQLite storage (replacing JSON)
- Export to PDF / printable formats
- Search and filtering across content
- Tagging and cross-referencing exercises

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# / .NET 8 |
| UI Framework | [Avalonia UI](https://avaloniaui.net/) |
| Architecture | MVVM — [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/) |
| Storage | JSON (SQLite migration planned) |
| Platform | Windows, Linux |

---

## Architecture overview

TeacherDesk follows the **MVVM pattern** throughout:

- **Models** — Plain C# classes representing the domain (`Course`, `Sequence`, `Lesson`, `Exercise`), each implementing `IStorable` for a consistent storage interface.
- **ViewModels** — Expose data and commands to the UI via `ObservableProperty` and `RelayCommand` (CommunityToolkit.Mvvm). Navigation is handled through shared `Action<ViewModelBase>` delegates, keeping ViewModels decoupled from each other.
- **Views** — Avalonia XAML views, resolved automatically from ViewModels via a `ViewLocator`.
- **Storage** — A generic `JsonStorageService<T>` handles serialization today, designed for a future drop-in SQLite replacement.

---

## Getting started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Run locally

```bash
git clone https://github.com/Zapratkyn/TeacherDesk
cd TeacherDesk
dotnet run --project TeacherDesk
```

> **Note:** TeacherDesk is in early development. Expect rough edges and breaking changes between commits.

---

## Project context

TeacherDesk is a portfolio project developed as part of a career transition into software development, after completing the **École 19 Brussels** Common Core. It serves as both a practical learning vehicle for C# and Avalonia UI, and a genuinely useful tool born from experience in the classroom.

---

## License

MIT