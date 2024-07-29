using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.DTOs;

public record class UpdateTaskDto(
    [Required][StringLength(50)]string Task,
    DateOnly DueDate,
    int PriorityId,
    bool InProgress,
    bool Completed
);
