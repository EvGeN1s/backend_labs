using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Task;
using ScrumBoardLibrary.Exceptions;

namespace ScrumBoardLibrary.Board;

public class Board : IBoard
{
    public Board(string name)
    {
        GUID = Guid.NewGuid().ToString();
        Name = name;
        _columnList = new List<IColumn>();
    }

    private const int MAX_COL = 10;

    private readonly List<IColumn> _columnList;

    public string GUID { get; }

    public string Name { get; set; }

    public void AddColumn(IColumn column)
    {
        if (_columnList.Count >= MAX_COL)
        {
            throw new ColumnLimitExceededException();
        }
        if (_columnList.Contains(column))
        {
            throw new ColumnAlreadyExistsException();
        }
        _columnList.Add(column);
    }

    public void EditColumnName(string GUID, string name)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].GUID == GUID)
            {
                _columnList[i].Name = name;
                return;
            }
        }
        throw new ColumnNotFoundException();
    }

    public void AddTask(ITask task, int columnNum = 0)
    {
        if (columnNum < 0 || columnNum >= _columnList.Count)
        {
            throw new ColumnNotFoundException();
        }
        _columnList[columnNum].AddTask(task);
    }

    public ITask GetTask(string GUID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            ITask? result = _columnList[i].GetTask(GUID);
            if (result != null)
            {
                return result;
            }
        }
        throw new TaskNotFoundException();
    }

    public IColumn GetColumn(string GUID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].GUID == GUID)
            {
                return _columnList[i];
            }
        }
        throw new ColumnNotFoundException();
    }

    public List<IColumn> GetAllColumn()
    {
        return _columnList;
    }

    public void EditTask(string GUID, string name, string description, TaskPriority priority)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].EditTask(GUID, name, description, priority))
            {
                return;
            }
        }
        throw new TaskNotFoundException();
    }

    public void DeleteTask(string GUID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].DeleteTask(GUID))
            {
                return;
            }
        }
        throw new TaskNotFoundException();
    }

    public void DeleteColumn(string GUID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].GUID == GUID)
            {
                _columnList.RemoveAt(i);
                return;
            }
        }
        throw new ColumnNotFoundException();
    }

    public void TransferTask(string finalColumnGUID, string taskGUID)
    {
        ITask task = GetTask(taskGUID);
        DeleteTask(task.GUID);
        AddTask(task, GetNumColumn(finalColumnGUID));
    }

    private int GetNumColumn(string GUID)
    {
        for (int i = 0; i < _columnList.Count; i++)
        {
            if (_columnList[i].GUID == GUID)
            {
                return i;
            }
        }
        throw new ColumnNotFoundException();
    }
}

