using ToDoList.DTOs;

namespace ToDoList.Server;

public class ToDo
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Done { get; private set; }
    public DateTime? Time { get; private set; }
    public DateTime? Deadline { get; private set; }

    public ToDo(AddToDo dto)
    {
        Id = Guid.NewGuid();
        Title = dto.Title;
        Description = dto.Description;
        Created = DateTime.UtcNow;
        Time = dto.Time;
        Deadline = dto.Deadline;
    }

    public void Complete()
    {
        Done = DateTime.UtcNow;
    }
}