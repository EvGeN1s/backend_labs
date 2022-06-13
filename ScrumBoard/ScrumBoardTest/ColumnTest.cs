using Xunit;
using System.Collections.Generic;
using ScrumBoardLibrary.Task;
using ScrumBoardLibrary.Column;

namespace ScrumBoardTest
{
    public class ColumnTest
    {
        [Fact]
        public void CreateColumn_WithProperties()
        {
            string columnName = "Column name";

            IColumn column = new Column(columnName);

            Assert.False(string.IsNullOrEmpty(column.GUID));
            Assert.Equal(columnName, column.Name);
            Assert.Empty(column.GetAllTask());
        }

        [Fact]
        public void ChangeColumnName_NameWillChange()
        {
            string newColumnName = "New column name";
            IColumn column = new Column("Column name");

            column.Name = newColumnName;

            Assert.Equal(newColumnName, column.Name);
        }

        [Fact]
        public void AddTask_InColumn_TaskWillBeAdded()
        {
            string columnName = "Column name";
            ITask task = new Task("Task", "Task description", TaskPriority.Medium);
            IColumn column = new Column(columnName);

            column.AddTask(task);

            Assert.Equal(task, column.GetAllTask()[0]);
        }

        [Fact]
        public void GetTask_FromColumn_ReturnTask()
        {
            ITask task = new Task("Task", "Task name", TaskPriority.Medium);
            IColumn column = new Column("Column name");
            column.AddTask(task);

            ITask? retTask = column.GetTask(task.GUID);

            Assert.Equal(task, retTask);
        }

        [Fact]
        public void EditTask_InColumn_TaskWillChange()
        {
            string newTaskName = "New task";
            string newTaskDescription = "New task name";
            ITask task = new Task("Task", "Task description", TaskPriority.Medium);
            IColumn column = new Column("Column name");
            column.AddTask(task);

            column.EditTask(task.GUID, newTaskName, newTaskDescription, TaskPriority.High);

            ITask? retTask = column.GetTask(task.GUID);
            Assert.NotNull(retTask);
            Assert.Equal(newTaskName, retTask.Name);
            Assert.Equal(newTaskDescription, retTask.Description);
            Assert.Equal(TaskPriority.High, retTask.Priority);
        }

        [Fact]
        public void DeleteTask_InColumn_TaskWillDelete()
        {
            ITask task = new Task("Task", "Task name", TaskPriority.Medium);
            IColumn column = new Column("Column name");
            column.AddTask(task);

            column.DeleteTask(task.GUID);

            Assert.Null(column.GetTask(task.GUID));
        }

        [Fact]
        public void GetAllTask_FromColumn_ReturnAllTask()
        {
            ITask task1 = new Task("Task1", "Task description1", TaskPriority.Medium);
            ITask task2 = new Task("Task2", "Task description2", TaskPriority.Low);
            ITask task3 = new Task("Task3", "Task description3", TaskPriority.High);
            IColumn column = new Column("Collumn name");
            column.AddTask(task1);
            column.AddTask(task2);
            column.AddTask(task3);

            List<ITask> taskList = column.GetAllTask();

            Assert.Equal(new List<ITask>() { task1, task2, task3 }, taskList);
        }
    }
}
