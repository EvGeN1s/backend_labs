using ScrumBoardLibrary.Task;
using ScrumBoardLibrary.Exceptions;

namespace ScrumBoardLibrary.Column;

public class Column : IColumn
{
    public Column(string name)
    {
        GUID = Guid.NewGuid().ToString();
        Name = name;
        _tasksList = new List<ITask>();
    }

    public string GUID { get; }

    public string Name { get; set; }

    private readonly List<ITask> _tasksList;

    public void AddTask(ITask task)
    {
        if (_tasksList.Contains(task))
        {
            throw new TaskAlreadyExsistsException();
        }
        _tasksList.Add(task);
    }

    public ITask? GetTask(string GUID)
    {
        for (int i = 0; i < _tasksList.Count; i++)
        {
            if (_tasksList[i].GUID == GUID)
            {
                return _tasksList[i];
            }
        }
        return null;
    }

    public bool EditTask(string GUID, string name, string description, TaskPriority priority)
    {
        for (int i = 0; i < _tasksList.Count; i++)
        {
            if (_tasksList[i].GUID == GUID)
            {
                _tasksList[i].Name = name;
                _tasksList[i].Description = description;
                _tasksList[i].Priority = priority;
                return true;
            }
        }
        return false;
    }

    public bool DeleteTask(string GUID)
    {
        for (int i = 0; i < _tasksList.Count; i++)
        {
            if (_tasksList[i].GUID == GUID)
            {
                _tasksList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public List<ITask> GetAllTask()
    {
        return _tasksList;
    }

    public void DeleteAllTask()
    {
        _tasksList.Clear();
    }
}

