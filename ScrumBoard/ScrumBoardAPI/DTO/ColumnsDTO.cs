using ScrumBoardLibrary.Column;

namespace ScrumBoardAPI.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(IColumn column)
    {
        GUID = column.GUID;
        Name = column.Name;
        Tasks = column.GetAllTask().Select(task => new TaskDTO(task));
    }

    public string GUID { get; set; }

    public string Name { get; set; }

    public IEnumerable<TaskDTO> Tasks { get; set; }

}
