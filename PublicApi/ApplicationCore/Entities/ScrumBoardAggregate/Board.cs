namespace ApplicationCore.Entities.ScrumBoardAggregate
{
    public class Board
    {
        public Board(string boardName)
        {
            BoardName = boardName;
            Columns = new List<Column>();
        }

        public int BoardUnicalID { get; set; }
        public string BoardName { get; set; }
        public List<Column> Columns { get; set; }
    }
}
