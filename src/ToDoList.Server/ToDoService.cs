using AutoMapper;
using ToDoList.DTOs;

namespace ToDoList.Server;

public interface IToDoService
{
    Task<ToDoResponse[]> GetTodos();
    Task<ToDoResponse[]> GetDone();
    Task AddToDo(AddToDo dto);
    Task CompleteToDo(Guid id);
    Task DeleteToDo(Guid id);
}

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _repository;
    private readonly IMapper _mapper;

    public ToDoService(IToDoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ToDoResponse[]> GetTodos()
    {
        var todos = await _repository.Get();
        return _mapper.Map<ToDoResponse[]>(todos);
    }

    public async Task<ToDoResponse[]> GetDone()
    {
        const bool completed = true;
        var todos = await _repository.Get(completed);
        return _mapper.Map<ToDoResponse[]>(todos);
    }

    public async Task AddToDo(AddToDo dto)
    {
        var toDo = new ToDo(dto);
        await _repository.Add(toDo);
    }

    public async Task CompleteToDo(Guid id)
    {
        var toDo = await _repository.Get(id);
        toDo.Complete();
        await _repository.Update(toDo);
    }

    public async Task DeleteToDo(Guid id)
    {
        await _repository.Delete(id);
    }
}