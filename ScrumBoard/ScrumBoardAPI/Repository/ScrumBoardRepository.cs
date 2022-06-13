using Microsoft.Extensions.Caching.Memory;
using ScrumBoardAPI.DTO;
using ScrumBoardLibrary.Board;
using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Task;
using Task = ScrumBoardLibrary.Task.Task;
using ScrumBoardAPI.Exception;

namespace ScrumBoardAPI.Repository;

public class ScrumBoardRepository : IScrumBoardRepository
{
    private readonly IMemoryCache _memoryCache;

    public ScrumBoardRepository(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void AddBoard(CreateBoardDTO param)
    {
        List<IBoard> boards;
        try
        {
            boards = GetListBoards();
        }
        catch (ListBoardsEmptyException)
        {
            boards = new List<IBoard>();
        }

        boards.Add(new Board(param.Name));

        _memoryCache.Set("boards", boards);
    }

    public BoardDTO GetBoard(string boardGUID)
    {
        return new BoardDTO(GetListBoards()[GetIndexBoard(boardGUID)]);
    }

    public IEnumerable<BoardDTO> GetAllBoard()
    {
        return GetListBoards().Select(board => new BoardDTO(board));
    }

    public void DeleteBoard(string boardGUID)
    {
        List<IBoard> boards = GetListBoards();

        for (int i = 0; i < boards.Count; i++)
        {
            if (boards[i].GUID == boardGUID)
            {
                boards.RemoveAt(i);
                _memoryCache.Set("boards", boards);
                return;
            }
        }
        throw new BoardNotFoundException();
    }

    public void AddColumn(string boardGUID, CreateColumnDTO param)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].AddColumn(new Column(param.Name));

        _memoryCache.Set("boards", boards);
    }

    public void EditColumn(string boardGUID, EditColumnDTO param)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].EditColumnName(param.GUID, param.Name);

        _memoryCache.Set("boards", boards);
    }

    public void DeleteColumn(string boardGUID, string columnGUID)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].DeleteColumn(columnGUID);

        _memoryCache.Set("boards", boards);
    }


    public void AddTask(string boardGUID, CreateTaskDTO param)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].AddTask(
            new Task(param.Name, param.Description, GetTaskPriority(param.Priority))
        );

        _memoryCache.Set("boards", boards);
    }

    public void EditTask(string boardGUID, EditTaskDTO param)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].EditTask(
            param.GUID, param.Name, param.Description, GetTaskPriority(param.Priority)
        );

        _memoryCache.Set("boards", boards);
    }

    public void DeleteTask(string boardGUID, string taskGUID)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].DeleteTask(taskGUID);

        _memoryCache.Set("boards", boards);
    }

    public void TransferTask(string boardGUID, string taskGUID, TransferTaskDTO param)
    {
        List<IBoard> boards = GetListBoards();

        boards[GetIndexBoard(boardGUID)].TransferTask(param.columnGUID, taskGUID);

        _memoryCache.Set("boards", boards);
    }

    private int GetIndexBoard(string boardGUID)
    {
        List<IBoard> boards = GetListBoards();

        for (int i = 0; i < boards.Count; i++)
        {
            if (boards[i].GUID == boardGUID)
            {
                return i;
            }
        }
        throw new BoardNotFoundException();
    }

    private List<IBoard> GetListBoards()
    {
        _memoryCache.TryGetValue("boards", out List<IBoard> boards);

        if (boards == null)
        {
            throw new ListBoardsEmptyException();
        }
        return boards;
    }

    private static TaskPriority GetTaskPriority(int priority)
    {
        return priority switch
        {
            0 => TaskPriority.Low,
            1 => TaskPriority.Medium,
            2 => TaskPriority.High,
            _ => throw new UndefinedPriorityException(),
        };
    }
}
