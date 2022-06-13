using ScrumBoardLibrary.Column;
using ScrumBoardLibrary.Task;

namespace ScrumBoardLibrary.Board;

public interface IBoard
{
    public string GUID { get; }

    public string Name { get; set; }

    public void AddColumn(IColumn column);

    public void EditColumnName(string GUID, string name);

    public void AddTask(ITask task, int columnNum = 0);

    public ITask GetTask(string GUID);

    public IColumn GetColumn(string GUID);

    public List<IColumn> GetAllColumn();

    public void EditTask(string GUID, string name, string description, TaskPriority priority);

    public void DeleteTask(string GUID);

    public void DeleteColumn(string GUID);

    public void TransferTask(string finalColumnGUID, string taskGUID);
}
