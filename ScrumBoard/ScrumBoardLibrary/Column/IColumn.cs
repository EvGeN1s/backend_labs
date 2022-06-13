using ScrumBoardLibrary.Task;

namespace ScrumBoardLibrary.Column;

public interface IColumn
{
    public string GUID { get; }

    public string Name { get; set; }

    public void AddTask(ITask task);

    public ITask? GetTask(string GUID);

    public bool EditTask(string GUID, string name, string description, TaskPriority priority);

    public bool DeleteTask(string GUID);

    public List<ITask> GetAllTask();

    public void DeleteAllTask();
}
