namespace ApplicationCore.Entities.ScrumBoardAggregate
{
    public enum Priority
    {
        HIGH,
        NORMAL,
        LOW,
    }
    public class Task
    {
        public Task(string taskName, string description, int taskPriority, int columnID)
        {
            TaskName = taskName;
            Description = description;
            TaskPriority = taskPriority;
            ColumnID = columnID;
        }
        public int ColumnID { get; set; }
        public Column Column { get; set; }
        public int TaskUnicalId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int TaskPriority { get; set; }
    }
}
