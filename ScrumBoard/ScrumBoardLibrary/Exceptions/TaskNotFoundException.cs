namespace ScrumBoardLibrary.Exceptions;

public class TaskNotFoundException : System.Exception
{
    public TaskNotFoundException() : base("Task not found.")
    {

    }
}

