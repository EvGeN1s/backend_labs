using ScrumBoardAPI.DTO;

namespace ScrumBoardAPI.Repository;

public interface IScrumBoardRepository
{
    public void AddBoard(CreateBoardDTO param);

    public BoardDTO GetBoard(string guid);

    public IEnumerable<BoardDTO> GetAllBoard();

    public void DeleteBoard(string boardGUID);


    public void AddColumn(string boardGUID, CreateColumnDTO param);

    public void EditColumn(string boardGUID, EditColumnDTO param);

    public void DeleteColumn(string boardGUID, string columnGUID);


    public void AddTask(string boardGUID, CreateTaskDTO param);

    public void EditTask(string boardGUID, EditTaskDTO param);

    public void DeleteTask(string boardGUID, string taskGUID);

    public void TransferTask(string boardGUID, string taskGUID, TransferTaskDTO param);
}
