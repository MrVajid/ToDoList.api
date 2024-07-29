using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Entities;

namespace ToDoList.Api.Data;

public class ToDoContext(DbContextOptions<ToDoContext> options) : DbContext(options)
{
    public DbSet<Entities.Task> Tasks => Set<Entities.Task>();
    public DbSet<Priority> Priorities => Set<Priority>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Priority>().HasData(
            new {Id = 1, Value = "High"},
            new {Id = 2, Value = "Medium"},
            new {Id = 3, Value = "Low"}
        );
    }
}
