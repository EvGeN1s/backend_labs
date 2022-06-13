namespace ScrumBoardLibrary.Exceptions;

public class TaskAlreadyExsistsException : System.Exception
{
    public TaskAlreadyExsistsException() : base("Task already exsists.")
    {

    }
}

