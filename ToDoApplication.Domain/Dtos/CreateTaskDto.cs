namespace ToDoApplication.Domain.Dtos;

public class CreateTaskDto
{
    public required string Title { get; set; }
    public string? Description { get; set; }
}