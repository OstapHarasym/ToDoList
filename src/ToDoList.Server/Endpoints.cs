using ToDoList.DTOs;

namespace ToDoList.Server;

public static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/todo", async (IToDoService service) =>
        {
            var todos = await service.GetTodos();
            return Results.Ok(todos);
        });
        
        app.MapGet("/done", async (IToDoService service) =>
        {
            var todos = await service.GetDone();
            return Results.Ok(todos);
        });

        app.MapPost("/todo", async (AddToDo toDo, IToDoService service) =>
        {
            await service.AddToDo(toDo);
            return Results.NoContent();
        });

        app.MapPost("/todo/{id}", async (Guid id, IToDoService service) =>
        {
            await service.CompleteToDo(id);
            return Results.NoContent();
        });

        app.MapDelete("/todo/{id}", async (Guid id, IToDoService service) =>
        {
            await service.DeleteToDo(id);
            return Results.NoContent();
        });
    }
}