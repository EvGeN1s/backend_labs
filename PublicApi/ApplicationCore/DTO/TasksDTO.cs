using Task = ApplicationCore.Entities.ScrumBoardAggregate.Task;

namespace ScrumBoardAPI.DTO;
public enum Priority
{
    HIGH,
    NORMAL,
    LOW,
}
public class TasksDTO
{
    public TasksDTO(Task task)
    {
        TaskUnicalId = task.TaskUnicalId;
        TaskName = task.TaskName;
        Description = task.Description;
        TaskPriority = ((Priority)task.TaskPriority).ToString();
    }

    public int TaskUnicalId { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
    public string TaskPriority { get; set; }
}
