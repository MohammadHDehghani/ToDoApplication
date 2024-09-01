using Microsoft.Extensions.DependencyInjection;
using ToDoApplication.Application.TaskRepository;
using ToDoApplication.Infrastructure.TasksRepository;

namespace ToDoApplication.Domain.Extensions;

public static class DependencyInjectionsExtensions
{
    public static IServiceCollection AddExtensions(this IServiceCollection services)
    {
        services.AddSingleton<IToDoTaskRepository, ToDoTaskRepository>();

        return services;
    }
}