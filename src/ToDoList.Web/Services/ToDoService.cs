using System.Net.Http.Json;
using ToDoList.DTOs;

namespace ToDoList.Web.Services;

public interface IToDoService
{
    public Task<ToDoResponse[]> GetTodos();
    public Task<ToDoResponse[]> GetDone();
    public Task AddToDo(AddToDo todo);
    public Task CompleteToDo(Guid todoId);
}

public class ToDoService : IToDoService
{
    private readonly HttpClient _httpClient;

    public ToDoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ToDoResponse[]> GetTodos()
    {
        return await _httpClient.GetFromJsonAsync<ToDoResponse[]>("/todo") ?? Array.Empty<ToDoResponse>();
    }

    public async Task<ToDoResponse[]> GetDone()
    {
        return await _httpClient.GetFromJsonAsync<ToDoResponse[]>("/done") ?? Array.Empty<ToDoResponse>();
    }

    public async Task AddToDo(AddToDo todo)
    {
        await _httpClient.PostAsJsonAsync("/todo", todo);
    }

    public async Task CompleteToDo(Guid todoId)
    {
        await _httpClient.PostAsync($"/todo/{todoId.ToString()}", null);
    }
}