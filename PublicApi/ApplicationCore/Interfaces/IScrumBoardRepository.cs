using ApplicationCore.DTO;
using ScrumBoardAPI.DTO;

namespace ApplicationCore.Interfaces
{
    public interface IScrumBoardRepository
    {
        public void AddBoard(CreateBoardDTO arg);
        public void AddColumn(int boardUnicalID, CreateColumnDTO arg);
        public void AddTask(int boardUnicalID, CreateTaskDTO arg);

        public BoardDTO GetBoard(int boardUnicalID);
        public IEnumerable<BoardDTO> GetAllBoard();

        public void DeleteBoard(int boardUnicalID);
        public void DeleteColumn(int columnUnicalID);
        public void DeleteTask(int taskUnicalID);

        public void MoveTask(int columnUnicalID, int taskUnicalID);
    }
}
