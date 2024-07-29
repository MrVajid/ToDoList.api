using ToDoList.Api.Data;
using ToDoList.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var ConnString = builder.Configuration.GetConnectionString("ToDoList");
builder.Services.AddSqlite<ToDoContext>(ConnString);
var app = builder.Build();

app.MapTasksEndpoints();
app.MapPrioritiesEndpoints();

await app.MigrateDbAsync();
app.Run();