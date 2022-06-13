using ApplicationCore.Entities.ScrumBoardAggregate;
using ScrumBoardAPI.DTO;

namespace ApplicationCore.DTO;

public class BoardDTO
{
    public BoardDTO(Board board)
    {
        BoardUnicalID = board.BoardUnicalID;
        BoardName = board.BoardName;

        List<ColumnsDTO> columnList = new();
        foreach (Column column in board.Columns)
        {
            columnList.Add(new ColumnsDTO(column));
        }

        Columns = columnList;
    }

    public int BoardUnicalID { get; set; }
    public string BoardName { get; set; }
    public List<ColumnsDTO> Columns { get; set; }
}
