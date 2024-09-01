using ToDoApplication.Domain.Task;

namespace ToDoApplication.Application.TaskRepository;

public interface IToDoTaskRepository
{
    public IReadOnlyCollection<TodoTask> GetTasks();
    public void AddTask(TodoTask task);
    public void RemoveTask(string taskId);
}