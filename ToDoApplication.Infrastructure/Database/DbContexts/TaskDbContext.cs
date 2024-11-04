using Microsoft.EntityFrameworkCore;
using ToDoApplication.Domain.Task;

namespace ToDoApplication.Infrastructure.Database.DbContexts
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<TodoTask> TodoItems { get; set; }
    }
}