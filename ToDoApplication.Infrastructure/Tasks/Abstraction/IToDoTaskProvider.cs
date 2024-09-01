using ToDoApplication.Domain.Dtos;

namespace ToDoApplication.Infrastructure.Tasks.Abstraction;

public interface IToDoTaskProvider
{
    public IReadOnlyCollection<TodoTask> GetTasks();
}