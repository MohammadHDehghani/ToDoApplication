using ToDoApplication.Application.TaskRepository;
using ToDoApplication.Domain.Exceptions;
using ToDoApplication.Domain.Task;

namespace ToDoApplication.Infrastructure.TasksRepository;

public class ToDoTaskRepository : IToDoTaskRepository
{
    public List<TodoTask> TodoTasks = [];

    public void AddTask(TodoTask task)
    {
        if (TodoTasks.Any(x => string.Equals(x.Id.ToString(), task.Id.ToString(), StringComparison.InvariantCulture)))
        {
            throw new RepeatedTaskIdException();
        }

        TodoTasks.Add(task);
    }

    public IReadOnlyCollection<TodoTask> GetTasks()
    {
        return TodoTasks;
    }

    public void RemoveTask(string taskId)
    {
        var taskToRemove = TodoTasks.Find(x => string.Equals(x.Id.ToString(), taskId, StringComparison.InvariantCulture));

        if (taskToRemove != null)
        {
            TodoTasks.Remove(taskToRemove);
        }
        else
        {
            throw new TaskNotFoundException();
        }
    }
}