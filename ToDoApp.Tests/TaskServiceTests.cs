using ToDoApp.Models;
using ToDoApp.Services;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Tests
{
    public class TaskServiceTests
    {
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _taskService = new TaskService(); // Create a new instance of TaskService for each test
        }

        [Fact]
        public void AddTask_ShouldAddTask_WhenTaskIsValid()
        {
            // Arrange
            var task = new TaskItem
            {
                Name = "Test Task",
                Priority = 1,
                Status = Enums.TaskStatus.NotStarted
            };

            // Act
            _taskService.AddTask(task);
            var allTasks = _taskService.GetAllTasks();

            // Assert
            Assert.Contains(task, allTasks);
        }

        [Fact]
        public void AddTask_ShouldThrowException_WhenTaskNameAlreadyExists()
        {
            // Arrange
            var task1 = new TaskItem
            {
                Name = "Duplicate Task",
                Priority = 1,
                Status = Enums.TaskStatus.NotStarted
            };

            var task2 = new TaskItem
            {
                Name = "Duplicate Task",
                Priority = 2,
                Status = Enums.TaskStatus.InProgress
            };

            _taskService.AddTask(task1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _taskService.AddTask(task2));
            Assert.Equal("A task with the same name already exists.", exception.Message);
        }

        [Fact]
        public void EditTask_ShouldUpdateTask_WhenTaskExists()
        {
            // Arrange
            var task = new TaskItem
            {
                Name = "Original Task",
                Priority = 1,
                Status = Enums.TaskStatus.NotStarted
            };

            _taskService.AddTask(task);

            var updatedTask = new TaskItem
            {
                Id = task.Id,
                Name = "Updated Task",
                Priority = 2,
                Status = Enums.TaskStatus.InProgress
            };

            // Act
            _taskService.EditTask(updatedTask);
            var allTasks = _taskService.GetAllTasks();

            // Assert
            var editedTask = allTasks.FirstOrDefault(t => t.Id == task.Id);
            Assert.NotNull(editedTask);
            Assert.Equal("Updated Task", editedTask.Name);
            Assert.Equal(2, editedTask.Priority);
            Assert.Equal(Enums.TaskStatus.InProgress, editedTask.Status);
        }

        [Fact]
        public void DeleteTask_ShouldRemoveTask_WhenTaskIsCompleted()
        {
            // Arrange
            var task = new TaskItem
            {
                Name = "Completed Task",
                Priority = 1,
                Status = Enums.TaskStatus.Completed
            };

            _taskService.AddTask(task);

            // Act
            _taskService.DeleteTask(task.Id);
            var allTasks = _taskService.GetAllTasks();

            // Assert
            Assert.DoesNotContain(task, allTasks);
        }

        [Fact]
        public void DeleteTask_ShouldNotRemoveTask_WhenTaskIsNotCompleted()
        {
            // Arrange
            var task = new TaskItem
            {
                Name = "In Progress Task",
                Priority = 1,
                Status = Enums.TaskStatus.InProgress // Task is not completed
            };

            _taskService.AddTask(task);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _taskService.DeleteTask(task.Id));
            Assert.Equal("Cannot delete a task that is not completed.", exception.Message);

            // Verify the task is still in the collection
            var allTasks = _taskService.GetAllTasks();
            Assert.Contains(task, allTasks);
        }


        [Fact]
        public void AddTask_ShouldThrowValidationError_WhenTaskNameIsNullOrEmpty()
        {
            // Arrange
            var taskWithEmptyName = new TaskItem
            {
                Name = "", // or set to null to test null case
                Priority = 1,
                Status = Enums.TaskStatus.NotStarted
            };

            // Act & Assert
            var validationContext = new ValidationContext(taskWithEmptyName);
            Assert.Throws<ValidationException>(() => Validator.ValidateObject(taskWithEmptyName, validationContext, validateAllProperties: true));
        }

        [Fact]
        public void AddTask_ShouldThrowValidationError_WhenPriorityIsInvalid()
        {
            // Arrange
            var taskWithInvalidPriority = new TaskItem
            {
                Name = "Invalid Priority Task",
                Priority = 0, // Invalid value (less than 1)
                Status = Enums.TaskStatus.NotStarted
            };

            // Act & Assert
            var validationContext = new ValidationContext(taskWithInvalidPriority);
            Assert.Throws<ValidationException>(() => Validator.ValidateObject(taskWithInvalidPriority, validationContext, validateAllProperties: true));
        }


    }
}
