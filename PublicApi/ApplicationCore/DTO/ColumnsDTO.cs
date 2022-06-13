using ApplicationCore.Entities.ScrumBoardAggregate;
using Task = ApplicationCore.Entities.ScrumBoardAggregate.Task;
namespace ScrumBoardAPI.DTO;

public class ColumnsDTO
{
    public ColumnsDTO(Column column)
    {
        ColumnUnicalID = column.ColumnUnicalID;
        ColumnName = column.ColumnName;

        List<TasksDTO> taskList = new();
        foreach (Task task in column.Tasks)
        {
            taskList.Add(new TasksDTO(task));
        }

        Tasks = taskList;
    }

    public int ColumnUnicalID { get; set; }
    public string ColumnName { get; set; }
    public IEnumerable<TasksDTO> Tasks { get; set; }
}
