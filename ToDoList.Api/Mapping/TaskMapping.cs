using ToDoList.Api.DTOs;
using ToDoList.Api.Entities;


namespace ToDoList.Api.Mapping;

public static class TaskMapping
{
    public static Entities.Task ToEntity(this CreateTaskDto task)
    {
        return new Entities.Task()
            {
                Desc = task.Task,
                DueDate = task.DueDate,
                PriorityId = task.PriorityId,
                InProgress = task.InProgress,
                Completed = task.Completed
            };
    }

    public static Entities.Task ToEntity(this UpdateTaskDto task, int id)
    {
        return new Entities.Task()
            {
                Id = id,
                Desc = task.Task,
                DueDate = task.DueDate,
                PriorityId = task.PriorityId,
                InProgress = task.InProgress,
                Completed = task.Completed
            };
    }
    public static TaskSummaryDto ToTaskSummaryDto(this Entities.Task task)
    {
        return new(
                task.Id,
                task.Desc,
                task.DueDate,
                task.Priority!.Value,
                task.InProgress,
                task.Completed
            );
    }

    public static TaskDetailsDto ToTaskDetailsDto(this Entities.Task task)
    {
        return new(
                task.Id,
                task.Desc,
                task.DueDate,
                task.PriorityId,
                task.InProgress,
                task.Completed
            );
    }
}
