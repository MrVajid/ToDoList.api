namespace ToDoList.Api.DTOs;

public record class TaskDetailsDto(
    int Id,
    string Task,
    DateOnly DueDate,
    int PriorityId,
    bool InProgress,
    bool Completed);
