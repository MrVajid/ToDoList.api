
# ToDo List REST API

This is a REST API built using ASP.NET Framework for managing a ToDo List web application. The API allows you to create, retrieve, update, and delete tasks.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### Clone the repository

```bash
git clone https://github.com/MrVajid/ToDoList.api.git
cd ToDoList.api
```

### Build and Run the API

1. Open the project in your preferred IDE.
2. Restore the dependencies and run the project.

Using .NET CLI:

```bash
dotnet restore
dotnet build
dotnet run
```

## Endpoints

| Method | Endpoint      | Description                | Request Body        | Response Body               |
|--------|---------------|----------------------------|---------------------|-----------------------------|
| GET    | `/tasks`      | Get all tasks              | None                | Array of tasks              |
| GET    | `/tasks/{id}` | Get task by ID             | None                | Task object or `404 Not Found` if task not found |
| POST   | `/tasks`      | Add a new task             | Task object         | `201 Created` if task is successfully created |
| PUT    | `/tasks/{id}` | Update an existing task    | Task object         | `204 No Content` if task is successfully updated |
| DELETE | `/tasks/{id}` | Delete a task              | None                | `204 No Content` if task is successfully deleted |

## Example Task Object

```json
{
    "id": 1,
    "task": "Test Task 1",
    "dueDate": "2024-08-04",
    "priority": "High",
    "inProgress": false,
    "completed": false
}
```
