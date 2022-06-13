using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ApplicationCore.Interfaces;
using ApplicationCore.DTO;
using ApplicationCore.Entities.ScrumBoardAggregate;
using Task = ApplicationCore.Entities.ScrumBoardAggregate.Task;
using ScrumBoardAPI.DTO;

namespace Infrastructure.Data
{
    public class ScrumBoardRepository : IScrumBoardRepository
    {
        private readonly ScrumBoardContext _databases;
        public ScrumBoardRepository(IConfiguration configuration)
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<ScrumBoardContext>();

            DbContextOptions<ScrumBoardContext>? options = contextOptionsBuilder.UseMySql(configuration.GetConnectionString("Default"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("Default"))).Options;

            _databases = new ScrumBoardContext(options);
        }

        public void AddBoard(CreateBoardDTO param)
        {
            Board board = new(param.BoardName);

            _databases.Boards.Add(board);
            _databases.SaveChanges();
        }

        public void AddColumn(int boardGUID, CreateColumnDTO param)
        {
            Board? board = _databases.Boards.Include(c => c.Columns)
                .Where(b => b.BoardUnicalID == boardGUID).FirstOrDefault();

            if (board != null)
            {
                if (board.Columns.Count() < 10)
                {
                    Column column = new(param.ColumnName, boardGUID);

                    _databases.Columns.Add(column);
                    _databases.SaveChanges();
                }

                else
                    throw new System.Exception("Collumns count must be equal or less than 10.");
            }

            else
                throw new System.Exception("Board not found.");
        }

        public void AddTask(int boardUnicalID, CreateTaskDTO param)
        {
            if ((param.TaskPriority < 0) || (param.TaskPriority > 2))
                throw new System.Exception("Task priority can't be less than 0 and more than 2.");

            Board? board = _databases.Boards.Include(c => c.Columns)
                .Where(b => b.BoardUnicalID == boardUnicalID).FirstOrDefault();

            if (board != null)
            {
                Column? column = board.Columns.FirstOrDefault();
                if (column != null)
                {
                    Task task = new(param.TaskName, param.TaskDescription, param.TaskPriority, column.ColumnUnicalID);

                    _databases.Tasks.Add(task);
                    _databases.SaveChanges();
                }

                else
                    throw new System.Exception("Column not found.");
            }

            else
                throw new System.Exception("Board not found.");
        }

        public BoardDTO GetBoard(int boardGUID)
        {
            Board? board = _databases.Boards.Include(c => c.Columns)
                .ThenInclude(t => t.Tasks).Where(b => b.BoardUnicalID == boardGUID).FirstOrDefault();

            if (board == null)
                throw new System.Exception("Board not found.");

            return new BoardDTO(board);
        }

        public IEnumerable<BoardDTO> GetAllBoard()
        {
            return _databases.Boards.Include(c => c.Columns).ThenInclude(t => t.Tasks).Select(board => new BoardDTO(board));
        }

        public void DeleteBoard(int boardGUID)
        {
            Board? board = _databases.Boards.Find(boardGUID);

            if (board != null)
            {
                _databases.Boards.Remove(board);
                _databases.SaveChanges();
            }

            else
                throw new System.Exception("Board not found.");
        }

        public void DeleteColumn(int columnGUID)
        {
            Column? column = _databases.Columns.Find(columnGUID);

            if (column != null)
            {
                _databases.Columns.Remove(column);
                _databases.SaveChanges();
            }

            else
                throw new System.Exception("Column not found.");
        }

        public void DeleteTask(int taskGUID)
        {
            Task? task = _databases.Tasks.Find(taskGUID);

            if (task != null)
            {
                _databases.Tasks.Remove(task);
                _databases.SaveChanges();
            }

            else
                throw new System.Exception("Task not found.");
        }

        public void TransferTask(int columnGUID, int taskGUID)
        {
            Task? task = _databases.Tasks.Find(taskGUID);
            Column? column = _databases.Columns.Find(columnGUID);

            if (task == null)
                throw new System.Exception("Task not found.");

            if (column == null)
                throw new System.Exception("Column not found.");

            task.ColumnID = columnGUID;

            _databases.SaveChanges();
        }
    }
}
