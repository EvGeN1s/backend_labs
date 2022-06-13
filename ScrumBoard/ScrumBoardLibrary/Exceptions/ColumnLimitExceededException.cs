namespace ScrumBoardLibrary.Exceptions;

public class ColumnLimitExceededException : System.Exception
{
    public ColumnLimitExceededException() : base("Collumn limit exceeded")
    {
    }
}

