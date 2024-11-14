namespace ToDoApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using ToDoApp.Enums;

    /// <summary>
    /// Represents a task item in the ToDo application.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        [Required(ErrorMessage = "Task name is required")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the priority of the task.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Priority must be a positive number")]
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        public TaskStatus? Status { get; set; }
    }
}
