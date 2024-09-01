namespace ToDoApplication.Domain.Dtos;

public class TodoTask
{
    private Guid Id { get; init; }
    private string Title { get; set; }
    private string Description { get; set; }
}