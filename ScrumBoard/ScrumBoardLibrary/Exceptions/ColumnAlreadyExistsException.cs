namespace ScrumBoardLibrary.Exceptions;

public class ColumnAlreadyExistsException : System.Exception
{
    public ColumnAlreadyExistsException() : base("Column already exsists.")
    {

    }
}

