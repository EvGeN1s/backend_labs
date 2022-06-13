using ScrumBoardLibrary.Board;

namespace ScrumBoardAPI.DTO;

public class BoardDTO
{
    public BoardDTO(IBoard board)
    {
        GUID = board.GUID;
        Name = board.Name;
        Columns = board.GetAllColumn().Select(column => new ColumnsDTO(column));
    }

    public string GUID { get; set; }

    public string Name { get; set; }

    public IEnumerable<ColumnsDTO> Columns { get; set; }
}
