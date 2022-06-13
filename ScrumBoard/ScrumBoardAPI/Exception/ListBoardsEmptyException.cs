namespace ScrumBoardAPI.Exception;

public class ListBoardsEmptyException : System.Exception
{
    public ListBoardsEmptyException() : base("Boards list is empty")
    {
    }
}
