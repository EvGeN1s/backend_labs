namespace ScrumBoardAPI.DTO;

public class EditTaskDTO
{
    public string? GUID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Priority { get; set; }
}
