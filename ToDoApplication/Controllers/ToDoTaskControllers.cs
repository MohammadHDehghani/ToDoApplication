using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Application.TaskRepository;
using ToDoApplication.Domain.Dtos;
using ToDoApplication.Domain.Exceptions;
using ToDoApplication.Domain.Task;

namespace ToDoApplication.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ToDoTaskControllers : ControllerBase
{
    private readonly IToDoTaskRepository _toDoTaskRepository;
    private readonly ILogger<ToDoTaskControllers> _logger;

    public ToDoTaskControllers(IToDoTaskRepository toDoTaskRepository, ILogger<ToDoTaskControllers> logger)
    {
        _toDoTaskRepository = toDoTaskRepository;
        _logger = logger;
    }

    [HttpGet(Name = "GetTasks")]
    public ActionResult<IEnumerable<TodoTask>> GetTasks()
    {
        var tasks = _toDoTaskRepository.GetTasks();
        return Ok(tasks);
    }

    [HttpPost("add", Name = "AddTask")]
    public IActionResult AddTask([FromBody] CreateTaskDto taskDto)
    {
        if (taskDto is null || string.IsNullOrEmpty(taskDto.Title))
        {
            return BadRequest("Task title must be provided at least.");
        }
        var newTask = new TodoTask
        {
            Id = Guid.NewGuid(),
            Title = taskDto.Title,
            Description = taskDto.Description ?? string.Empty
        };

        _toDoTaskRepository.AddTask(newTask);
        return CreatedAtRoute("GetTasks", new { id = newTask.Id }, newTask);
    }

    [HttpDelete("remove/{taskId}", Name = "RemoveTask")]
    public IActionResult RemoveTask(string taskId)
    {
        try
        { 
            _toDoTaskRepository.RemoveTask(taskId);
        }
        catch (TaskNotFoundException)
        {
            return Ok("Given task id not found.");
        }

        return Ok();
    }
}
