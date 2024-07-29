using ToDoList.Api.DTOs;
using ToDoList.Api.Entities;

namespace ToDoList.Api.Mapping;

public static class PriorityMapping
{
    public static PriorityDto ToDto(this Priority priority)
    {
        return new PriorityDto(priority.Id, priority.Value);
    }
}
