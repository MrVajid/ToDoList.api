using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Data;
using ToDoList.Api.DTOs;
using ToDoList.Api.Entities;
using ToDoList.Api.Mapping;

namespace ToDoList.Api.Endpoints;

public static class TasksEndpoints{
    
    public static RouteGroupBuilder MapTasksEndpoints(this WebApplication app){
        
        var group = app.MapGroup("tasks")
                       .WithParameterValidation();

        group.MapGet("/", async(ToDoContext dbContext) => 
            await dbContext.Tasks
                     .Include(task => task.Priority)
                     .Select(task => task.ToTaskSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());
        group.MapGet("/{id}", async(int id, ToDoContext dbContext) => 
        {
            Entities.Task? task = await dbContext.Tasks.FindAsync(id);
            return task is null ? Results.NotFound() : Results.Ok(task.ToTaskDetailsDto());
        })
        .WithName("GetTask");

        group.MapPost("/", async(CreateTaskDto newTask, ToDoContext dbContext) => {
            
            Entities.Task task = newTask.ToEntity();
            
            dbContext.Tasks.Add(task);
            await dbContext.SaveChangesAsync();
            
            return Results.CreatedAtRoute("GetTask", new {id = task.Id}, task.ToTaskDetailsDto());
        });

        group.MapPut("/{id}", async(int id, UpdateTaskDto updatedTask, ToDoContext dbContext) => {
            var existingTask = await dbContext.Tasks.FindAsync(id);
            if (existingTask is null) {
                return Results.NotFound();
            }
            dbContext.Entry(existingTask)
                     .CurrentValues
                     .SetValues(updatedTask.ToEntity(id));
            
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async(int id, ToDoContext dbContext) => {
            await dbContext.Tasks
                     .Where(task => task.Id == id)
                     .ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}
