namespace ScrumBoardAPI.DTO;
public class CreateTaskDTO
{
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public int TaskPriority { get; set; }
}
