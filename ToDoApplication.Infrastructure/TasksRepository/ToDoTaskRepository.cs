using ToDoApplication.Application.TaskRepository;
using ToDoApplication.Domain.Exceptions;
using ToDoApplication.Domain.Task;
using ToDoApplication.Infrastructure.Database.DbContexts;

namespace ToDoApplication.Infrastructure.TasksRepository
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public ToDoTaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTask(TodoTask task)
        {
            if (_dbContext.TodoItems.Any(x => x.Id == task.Id))
            {
                throw new RepeatedTaskIdException();
            }

            _dbContext.TodoItems.Add(task);
            _dbContext.SaveChanges();
        }

        public IReadOnlyCollection<TodoTask> GetTasks()
        {
            return _dbContext.TodoItems.ToList();
        }

        public void RemoveTask(string taskId)
        {
            var taskToRemove = _dbContext.TodoItems
                .FirstOrDefault(x => x.Id.ToString() == taskId);

            if (taskToRemove != null)
            {
                _dbContext.TodoItems.Remove(taskToRemove);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new TaskNotFoundException();
            }
        }
    }
}