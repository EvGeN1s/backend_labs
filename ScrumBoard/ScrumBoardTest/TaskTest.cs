using Xunit;
using ScrumBoardLibrary.Task;
namespace ScrumBoardTest
{
    public class TaskTest
    {
        [Fact]
        public void CreateTask_WithProperties()
        {
            string taskName = "Task";
            string taskDescription = "Task description";
            
            ITask task = new Task(taskName, taskDescription, TaskPriority.Medium);
            
            Assert.False(string.IsNullOrEmpty(task.GUID));
            Assert.Equal(taskName, task.Name);
            Assert.Equal(taskDescription, task.Description);
            Assert.Equal(TaskPriority.Medium, task.Priority);
        }

        [Fact]
        public void ChangeTaskName_NameWillChange()
        {
            string newTaskName = "New task name";
            ITask task = new Task("Task", "Task descripiton", TaskPriority.Medium);
            
            task.Name = newTaskName;
            
            Assert.Equal(newTaskName, task.Name);
        }

        [Fact]
        public void ChangeTaskDescription_DescriptionWillChange()
        {
            string newTaskDescription = "New task name";
            ITask task = new Task("Task", "Task name", TaskPriority.Medium);
         
            task.Description = newTaskDescription;
            
            Assert.Equal(newTaskDescription, task.Description);
        }

        [Fact]
        public void ChangeTaskPriority_PriorityWillChange()
        {
            ITask task = new Task("Task", "Task name", TaskPriority.Medium);
            
            task.Priority = TaskPriority.Low;
            
            Assert.Equal(TaskPriority.Low, task.Priority);
        }
    }
}
