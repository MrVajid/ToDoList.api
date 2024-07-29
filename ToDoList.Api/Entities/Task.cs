namespace ToDoList.Api.Entities;

public class Task
{
    public int Id {get; set;}
    public required string Desc {get; set;}
    public DateOnly DueDate {get; set;}
    public int PriorityId {get; set;}
    public Priority? Priority {get; set;}
    public bool InProgress {get; set;}
    public bool Completed {get; set;}
}
