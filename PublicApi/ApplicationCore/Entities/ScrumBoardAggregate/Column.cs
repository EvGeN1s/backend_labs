namespace ApplicationCore.Entities.ScrumBoardAggregate
{
    public class Column
    {
        public Column(string columnName, int boardID)
        {
            ColumnName = columnName;
            BoardID = boardID;
            Tasks = new List<Task>();
        }

        public Board Board { get; set; }
        public int ColumnUnicalID { get; set; }
        public string ColumnName { get; set; }
        public int BoardID { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
