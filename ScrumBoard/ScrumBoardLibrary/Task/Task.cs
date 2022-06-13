namespace ScrumBoardLibrary.Task;

public class Task : ITask
{
    public Task(string name, string description, TaskPriority priority)
    {
        GUID = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        Priority = priority;
    }

    public string GUID { get; }

    public string Name { get; set; }

    public string Description { get; set; }

    public TaskPriority Priority { get; set; }
}

