namespace ToDoApplication.Domain.Task;

public class TodoTask
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}