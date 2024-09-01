using ToDoApplication.Domain.Dtos;
using ToDoApplication.Infrastructure.Tasks.Abstraction;

namespace ToDoApplication.Infrastructure.Tasks;

public class ToDoTaskProvider : IToDoTaskProvider
{
    private IReadOnlyCollection<TodoTask> todoTasks = new List<TodoTask>();

    public ToDoTaskProvider()
    {
        
    }

    public ToDoTaskProvider(IReadOnlyCollection<TodoTask> tasks)
    {
        todoTasks = tasks;
    }

    public IReadOnlyCollection<TodoTask> GetTasks()
    {
        throw new NotImplementedException();
    }
}