using FluentAssertions;
using ToDoApplication.Domain.Exceptions;
using ToDoApplication.Domain.Task;
using ToDoApplication.Infrastructure.TasksRepository;

namespace ToDoApplication.Infrastructure.UnitTests.TaskRepository;

public class ToDoTaskRepositoryTests
{
    private const string SampleGuid = "9aac729f-f076-49e1-998e-909c20dfb9d3";
    private readonly ToDoTaskRepository _sut;

    public ToDoTaskRepositoryTests()
    {
        _sut = new ToDoTaskRepository();
    }

    [Fact]
    public void GetTasks_ShouldReturnEmptyListOfTasks_WhenThereIsNoTasks()
    {
        // Arrange

        // Act
        var actual = _sut.GetTasks();

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void GetTasks_ShouldReturnListOfTasks_WhenThereIsTasks()
    {
        // Arrange
        var expected = new List<TodoTask>
        {
            new TodoTask
            {
                Id = Guid.Parse(SampleGuid),
                Title = "Test",
                Description = "Test",
            }
        };
        _sut.TodoTasks = expected;

        // Act
        var actual = _sut.GetTasks();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void AddTask_ShouldThrowRepeatedTaskIdException_WhenGivenTaskIdIsCurrentlyExisted()
    {
        // Arrange
        var tasks = new List<TodoTask>
        {
            new TodoTask
            {
                Id = Guid.Parse(SampleGuid),
                Title = "title",
                Description = "description"
            }
        };
        _sut.TodoTasks = tasks;

        var taskToAdd = new TodoTask
        {
            Id = Guid.Parse(SampleGuid),
            Title = "newTitle",
            Description = "newDescription",
        };

        // Act
        var action = () => _sut.AddTask(taskToAdd);

        // Assert
        action.Should().Throw<RepeatedTaskIdException>();
    }

    [Fact]
    public void AddTask_ShouldAddGivenTaskToTasks_Whenever()
    {
        // Arrange
        var task = new TodoTask
        {
            Id = Guid.Parse(SampleGuid),
            Title = "Test",
            Description = "Test"
        };

        // Act
        _sut.AddTask(task);

        // Assert
        _sut.TodoTasks.Should().Contain(task);
    }

    [Fact]
    public void RemoveTask_ShouldThrowsTaskNotFoundException_WhenGivenTaskIdDoesNotExist()
    {
        // Arrange

        // Act
        var action = () => _sut.RemoveTask(SampleGuid);

        // Assert
        action.Should().Throw<TaskNotFoundException>();
    }

    [Fact]
    public void RemoveTask_ShouldRemoveTaskWithGivenIdFromTasks_WhenGivenTaskIdExists()
    {
        // Arrange
        var task = new TodoTask
        {
            Id = Guid.Parse(SampleGuid),
            Title = "Test",
            Description = "Test"
        };
        var tasks = new List<TodoTask> { task };
        _sut.TodoTasks = tasks;

        // Act
        _sut.RemoveTask(SampleGuid);

        // Assert
        _sut.TodoTasks.Should().NotContain(task);
    }
}