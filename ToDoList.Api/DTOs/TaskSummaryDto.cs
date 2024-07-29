namespace ToDoList.Api.DTOs;

public record class TaskSummaryDto(
    int Id,
    string Task,
    DateOnly DueDate,
    string Priority,
    bool InProgress,
    bool Completed);
