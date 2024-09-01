namespace ToDoApplication.Domain.Exceptions;

public class RepeatedTaskIdException : Exception
{
    public RepeatedTaskIdException()
    {
    }

    public RepeatedTaskIdException(string? message) : base(message)
    {
    }

    public RepeatedTaskIdException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}