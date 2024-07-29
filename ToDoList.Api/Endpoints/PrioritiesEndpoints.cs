using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Data;
using ToDoList.Api.DTOs;
using ToDoList.Api.Entities;
using ToDoList.Api.Mapping;

namespace ToDoList.Api.Endpoints;

public static class PrioritiesEndpoints
{
    public static RouteGroupBuilder MapPrioritiesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("priorities");
        group.MapGet("/", async (ToDoContext dbContext) =>
            await dbContext.Priorities
                           .Select(priority => priority.ToDto())
                           .AsNoTracking() 
                           .ToListAsync()
        );
        return group;
                           
    }
}
