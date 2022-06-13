namespace ScrumBoardLibrary.Task;

public enum TaskPriority
{
    High,
    Medium,
    Low
}

public interface ITask
{
    public string GUID { get; }

    public string Name { get; set; }

    public string Description { get; set; }

    public TaskPriority Priority { get; set; }
}

