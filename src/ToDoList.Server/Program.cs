using ToDoList.Server;
using ToDoList.Server.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddIoC();
builder.AddCors();

var app = builder.Build();

app.UseCors();

app.MapEndpoints();

app.Run();