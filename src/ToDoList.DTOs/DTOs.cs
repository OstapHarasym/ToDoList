namespace ToDoList.DTOs;

public class AddToDo
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? Time { get; set; }
    public DateTime? Deadline { get; set; }
}

public record ToDoResponse(Guid Id, string Title, string Description, DateTime? Time, DateTime? Deadline);