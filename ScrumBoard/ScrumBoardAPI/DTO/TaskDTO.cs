using ScrumBoardLibrary.Task;

namespace ScrumBoardAPI.DTO;

public class TaskDTO
{
    public TaskDTO(ITask task)
    {
        GUID = task.GUID;
        Name = task.Name;
        Description = task.Description;
        Priority = task.Priority.ToString();
    }

    public string GUID { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Priority { get; set; }
}
